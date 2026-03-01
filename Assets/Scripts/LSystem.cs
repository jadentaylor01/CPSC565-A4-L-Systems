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
        this.currentString = axiom;
    }

    /// <summary>
    /// Steps the LSystem according to the probability distribution defined
    /// on the rule. The probabilies do not have to sum to 1.
    /// If they are less than 1: There is a chance no rule is applied.
    /// If they are more than 1: The rules later in the list that surpass 1 will be ignored.
    /// </summary>
    public void stochasticStep()
    {
        List<Symbol> newString = new List<Symbol>();

        foreach (Symbol s in currentString)
        {
            // generate a random value for each character
            float random = Random.Range(0f, 1.0f);    
            // We accumulate the probability, the random number will
            // only fall within one of the ranges
            float probabilityAccumulation = 0f;

            bool ruleApplied = false;
            foreach (Rule rule in rules)
            {
                // Check if a rule matches the current character
                if (s.symbol == rule.predecessor && !ruleApplied)
                {
                    // Add the probability of that rule to the accumulation
                    probabilityAccumulation += rule.probability;

                    // Only apply the rule if the random number
                    // is within the rules probability range.                    
                    if (random < probabilityAccumulation)
                    {
                        newString.AddRange(rule.successor);
                        ruleApplied = true;
                        break;
                    }
                }
            }

            // If no rule was applied, replace the character
            if (!ruleApplied)
            {
                newString.Add(s);
            }
        }
        currentString = newString;
    }

    /// <summary>
    /// Steps the LSystem, taking the first rule present in the rule list.
    /// Ignores any probability, and duplicate character rules.
    /// </summary>
    public void deterministicStep()
    {
        List<Symbol> newString = new List<Symbol>();

        foreach (Symbol s in currentString)
        {
            bool ruleApplied = false;
            foreach (Rule rule in rules)
            {
                // Check if a rule matches the current character
                if (s.symbol == rule.predecessor)
                {
                    // Apply the rule to the new string
                    newString.AddRange(rule.successor);
                    ruleApplied = true;
                    break;
                }
            }

            // If no rule was applied, replace the character
            if (!ruleApplied)
            {
                newString.Add(s);
            }
        }
        currentString = newString;
    }

    public void reset()
    {
        currentString = axiom;
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

    
