using UnityEngine;
using System.Collections.Generic;


public class Rule
{
    public char predecessor;
    public List<Symbol> successor;
    public float probability;
    
    public Rule(char predecessor, List<Symbol> successor)
    {
        this.predecessor = predecessor;
        this.successor = successor;
        this.probability = 1;
    }

    public Rule(char predecessor, List<Symbol> successor, float probability)
    {
        this.predecessor = predecessor;
        this.successor = successor;
        this.probability = probability;
    }
}
