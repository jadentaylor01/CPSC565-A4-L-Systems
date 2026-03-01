using UnityEngine;
using System.Collections.Generic;

public class SystemManager : MonoBehaviour
{
    public List<LSystem> systems = new List<LSystem>();
    public GameObject turtlePrefab;
    public int selectedRuleset = 0;
    GameObject turtle;
    Turtle turtleScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        systems = new List<LSystem>();
        
        // Ruleset 1
        List<Rule> ruleset1 = new List<Rule>();
        ruleset1.Add(new Rule('F', generateSymbols("F[+F]F[-F]F")));
        // rules.Add(new Rule('+', generateSymbols("--F"),0.1f));
        // rules.Add(new Rule('-', generateSymbols("+F")));
        systems.Add(new LSystem(generateSymbols("F"),ruleset1));

        // Ruleset 2
        List<Rule> ruleset2 = new List<Rule>();
        ruleset2.Add(new Rule('F', generateSymbols("F[+F]F[-F][F]")));
        // rules.Add(new Rule('+', generateSymbols("--F"),0.1f));
        // rules.Add(new Rule('-', generateSymbols("+F")));
        systems.Add(new LSystem(generateSymbols("F"),ruleset2));

        // Generate the turtle
        turtle = Instantiate(turtlePrefab);
        turtleScript = turtle.GetComponent<Turtle>();
        turtleScript.loadSystem(systems[selectedRuleset]);
    }

    /// <summary>
    /// Steps the selected LSystem deterministically. If multiple rules are present it will ignore
    /// ones that are a larger index in the rules list and take the probability of the first
    /// occurence of a character to be 1. 
    /// </summary>
    public void stepD0LSystem()
    {
        systems[selectedRuleset].deterministicStep();
        turtleScript.loadSystem(systems[selectedRuleset]); 
    }

    /// <summary>
    /// Steps the selected LSystem stochastically. It applies the rules at a probability, 
    /// if the probabilities sum to 1, one of the rules will be applied guarenteed.
    /// See LSystem.stochasticStep() for full details of the rule probabilties.
    /// </summary>
    public void stepStochasticLSystem()
    {
        systems[selectedRuleset].stochasticStep();
        turtleScript.loadSystem(systems[selectedRuleset]); 
    }

    /// <summary>
    /// Resets the selected LSystem. Deletes any cylinders that have been generated,set the
    /// LSystem string back to the axiom, and places the turtle back at the starting position.
    /// </summary>
    public void resetLSystem()
    {
        turtleScript.deleteCylinders();
        systems[selectedRuleset].reset();
        turtle.transform.position = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Starts the turtle with the default or previously set parameters
    /// </summary>
    public void startTurtle()
    {
        turtleScript.interpretFullSystem();
    }
    /// <summary>
    /// Starts the turtle with new parameters.
    /// </summary>
    /// <param name="branchAngle">Angle that branches will rotate by on '+' or '-' symbols.</param>
    /// <param name="branchRadius">Radius of the branch cylinders.</param>
    /// <param name="symbolLength">Length of each branch segment that represents a 'F' symbol</param>
    public void startTurtle(float branchAngle, float branchRadius, float symbolLength)
    {
        setTurtleParameters(branchAngle, branchRadius, symbolLength);
        startTurtle();
    }

    /// <summary>
    /// Sets the turtle parameters which will be used when startTurtle() is called.
    /// </summary>
    /// <param name="branchAngle">Angle that branches will rotate by on '+' or '-' symbols.</param>
    /// <param name="branchRadius">Radius of the branch cylinders.</param>
    /// <param name="symbolLength">Length of each branch segment that represents a 'F' symbol</param>
    public void setTurtleParameters(float branchAngle, float branchRadius, float symbolLength)
    {
        turtleScript.moveDistance = symbolLength;
        turtleScript.cylinderRadius = branchRadius;
        turtleScript.rotateAngle = branchAngle;
    }

    /// <summary>
    /// Generates a list of symbols from a string.
    /// </summary>
    /// <param name="str">String of characters to convert</param>
    /// <returns>List of Symbols that represents the string of characters given</returns>
    public List<Symbol> generateSymbols(string str)
    {
        List<Symbol> symbols = new List<Symbol>();
        foreach (char c in str)
        {
            symbols.Add(new Symbol(c));
        }
        return symbols;
    }

    /// <summary>
    /// Gets the string which represent the current list of symbols for the selected LSystem.
    /// </summary>
    /// <returns>string of the current LSystem symbol list. </returns>
    public string getCurrentString()
    {
        return systems[selectedRuleset].getCurrentStringDisplay();
    }
}
