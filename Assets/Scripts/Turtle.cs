
using UnityEngine;
using static LGeom;
public class Turtle : MonoBehaviour
{
    public float moveDistance = 1f; 
    public float cylinderRadius = 0.01f;
    public float rotateAngle = 45;

    public Material material;
    bool color = false;
    private LSystem system;
    private int currentSymbolIndex = 0;

    public void loadSystem(LSystem system)
    {
        this.system = system;
    }

    // public void interpretSystem()
    // {
    //     foreach (Symbol s in system.currentString)
    //     {
    //         interpretSymbol(s);
    //     }
    // }

    public void interpretNextSymbol()
    {
        if (currentSymbolIndex >= system.currentString.Count) {
            return;
        }

        Symbol s = system.currentString[currentSymbolIndex];
        switch (s.symbol)
        {
            case 'F':
                Transform oldTransform = transform;
                
                if (color)
                {
                   LGeom.Cylinder(
                        oldTransform.position,
                        oldTransform.position + (transform.up*moveDistance),
                        cylinderRadius,
                        material
                    ); 
                } else
                {
                    LGeom.Cylinder(
                        oldTransform.position,
                        oldTransform.position + (transform.up*moveDistance),
                        cylinderRadius
                    ); 
                }
                color = !color;
                
                transform.position = oldTransform.position + (transform.up*moveDistance);
                break;
            case '+':
                transform.Rotate(new Vector3(0,0,-rotateAngle));
                break;
            case '-':
                transform.Rotate(new Vector3(0,0,rotateAngle));
                break;
            case '[':
                break;
            case ']':
                break;
        }
        currentSymbolIndex++;
    }
}
