using System.Collections.Generic;
using UnityEngine;


public class LSystem
{
    public List<Rule> rules;
    public List<Symbol> axiom;
    public List<Symbol> currentString;

    public LSystem(List<Symbol> axiom, List<Rule> rules)
    {
        this.rules = rules;
        this.axiom = axiom;
        this.currentString = new List<Symbol>(axiom);
    }

    public void step()
    {
        List<Symbol> newString = new List<Symbol>();

        foreach (Symbol s in currentString)
        {
            bool ruleFound = false;
            foreach (Rule rule in rules)
            {
                if (s.symbol == rule.predecessor)
                {
                    newString.AddRange(rule.successor);
                    ruleFound = true;
                }
            }

            if (!ruleFound)
            {
                newString.Add(s);
            }
        }
        currentString = newString;
    }

    public void reset()
    {
        currentString = new List<Symbol>(axiom);
    }

    public string getCurrentStringDisplay()
    {
        string curr = "";
        foreach (Symbol s in currentString)
        {
            curr += s.symbol;
        }
        return curr;
    }
}

    
