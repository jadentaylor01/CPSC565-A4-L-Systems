using UnityEngine;
using System.Collections.Generic;


public class Rule
{
    public char predecessor;
    public List<Symbol> successor;
    
    public Rule(char predecessor, List<Symbol> successor)
    {
        this.predecessor = predecessor;
        this.successor = successor;
    }
}
