using UnityEngine;
using System.Collections.Generic;

public class SystemManager : MonoBehaviour
{
    public List<LSystem> systems = new List<LSystem>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       
        List<Rule> rules = new List<Rule>();
        // F -> F[+F]F[-F]F
        rules.Add(new Rule('F', generateSymbols("F[+F]F[-F]F")));

        systems = new List<LSystem>();
        // Axiom F
        systems.Add(new LSystem(generateSymbols("F"),rules));
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
    }

}
