using UnityEngine;
using static LGeom;
using System.Collections.Generic;

public class Turtle : MonoBehaviour
{
    // Attributes that change the way the tree is generated
    public float moveDistance = 1f; 
    public float cylinderRadius = 0.01f;
    public float rotateAngle = 45;

    // For stepping through the interpretation
    public Material material;
    private bool color = true;
    private int currentSymbolIndex = 0;

    // The LSystem being interpretted
    public LSystem system;

    public List<GameObject> cylinders = new List<GameObject>();
    // To handle brackets in string
    private Stack<Vector3> positionStack = new Stack<Vector3>();
    private Stack<Quaternion> rotationStack = new Stack<Quaternion>();

    public void loadSystem(LSystem system)
    {
        currentSymbolIndex = 0;
        color = true;
        this.system = system;
    }

    public void interpretFullSystem()
    {
        while (interpretNextSymbol());
    }

    public bool interpretNextSymbol()
    {
        // Do not interpret if the turtle is at the end of the string
        if (currentSymbolIndex >= system.currentString.Count) {
            return false;
        }

        // Handle the different symbols in the alphabet
        Symbol s = system.currentString[currentSymbolIndex];
        switch (s.symbol)
        {
            case 'F':
                // Save the position before we move the turtle
                Transform oldTransform = transform;
                
                // Only so we can alternate colors to see segments better
                Material m = color ? material : null;
                // color = !color;

                // Generate the cylinder along the path
                cylinders.Add(LGeom.Cylinder(
                    oldTransform.position,
                    oldTransform.position + (transform.up*moveDistance),
                    cylinderRadius,
                    m
                )); 

                // Move the turtle along the path
                transform.position = oldTransform.position + (transform.up*moveDistance);
                break;
            case '+':
                // Rotate the turtle by the angle
                transform.Rotate(new Vector3(0,0,rotateAngle));
                break;
            case '-':
                // Rotate the turtle by the angle
                transform.Rotate(new Vector3(0,0,-rotateAngle));
                break;
            case '[':
                // Push the turtles current position and rotation to the stack
                positionStack.Push(transform.position);
                rotationStack.Push(transform.rotation);
                break;
            case ']':
                // Return the turtle the the top position and rotation on the stack
                transform.position = positionStack.Pop();
                transform.rotation = rotationStack.Pop();
                break;
        }
        currentSymbolIndex++;
        return true;
    }

    public void deleteCylinders()
    {
        foreach (GameObject cylinder in cylinders)
        {
            Destroy(cylinder);
        }
        cylinders = new List<GameObject>();
    }
}
