using UnityEngine;
using System.Collections.Generic;

public class SystemManager : MonoBehaviour
{
    public List<LSystem> systems = new List<LSystem>();
    public GameObject turtlePrefab;

    GameObject turtle;
    Turtle turtleScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        List<Rule> rules = new List<Rule>();
        // F -> F[+F]F[-F]F
        // rules.Add(new Rule('F', generateSymbols("F[+F]F[-F]F")));


        systems = new List<LSystem>();

        // Ruleset 1
        rules.Add(new Rule('F', generateSymbols("F[+F-F]F[-F+F]F")));
        rules.Add(new Rule('+', generateSymbols("--F")));
        rules.Add(new Rule('-', generateSymbols("+F")));
        systems.Add(new LSystem(generateSymbols("F"),rules));

        // Ruleset 2
        

        // Generate the turtle
        turtle = Instantiate(turtlePrefab);
        turtleScript = turtle.GetComponent<Turtle>();
        turtleScript.loadSystem(systems[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Symbol> generateSymbols(string str)
    {
        List<Symbol> symbols = new List<Symbol>();
        foreach (char c in str)
        {
            symbols.Add(new Symbol(c));
        }
        return symbols;
    }

    public string getCurrentString()
    {
        return systems[0].getCurrentStringDisplay();
    }

    public void stepLSystem()
    {
        systems[0].step();
        turtleScript.loadSystem(systems[0]); 
    }

    public void resetLSystem()
    {
        turtleScript.deleteCylinders();
        systems[0].reset();
        turtle.transform.position = new Vector3(0, 0, 0);
    }

    // public void startTurtle()
    // {
    //     return;
    // }
    public void startTurtle(float branchAngle, float branchRadius, float symbolLength)
    {
        turtleScript.moveDistance = symbolLength;
        turtleScript.cylinderRadius = branchRadius;
        turtleScript.rotateAngle = branchAngle;
        turtleScript.interpretFullSystem();
    }

    public void stepTurtle()
    {
        turtleScript.interpretNextSymbol();
    }

}
