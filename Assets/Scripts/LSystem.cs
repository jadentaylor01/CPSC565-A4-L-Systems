using System.Diagnostics;
using UnityEngine;

public class LSystem
{
    public List<Rule> rules;
    public List<Symbol> axiom;
    public List<Symbol> currentString;

    public LSystem(List<Rule> rules, List<Symbol> axiom)
    {
        this.rules = rules;
        this.axiom = axiom;
        this.currentString = new List<Symbol>(axiom);
    }
    
    public void step()
    {
        foreach (Rule rule in rules)
        {
            for (int i = 0; i < currentString.Count; i++)
            {
                if (currentString[i].symbol == rule.Predecessor)
                {
                    currentString.RemoveAt(i);
                    currentString.InsertRange(i, rule.Successor);
                }
            }
        }
    }

    public void reset()
    {
        currentString = new List<Symbol>(axiom);
    }
}
    
