using System;
using UnityEngine.Rendering;

public enum Symbol
{
    None,
    Cross,
    Circle
}

public static class SymbolExtensions
{
    public static Symbol GetOther(this Symbol symbol)
    {
        switch (symbol)
        {
            case Symbol.Circle: return Symbol.Cross;
            case Symbol.Cross: return Symbol.Circle;
            default: return Symbol.None;
        }
    }
    
    public static String ToCharacter(this Symbol symbol)
    {
        switch (symbol)
        {
            case Symbol.Circle: return "O";
            case Symbol.Cross: return "X";
            default: return "_";
        }
    }

    
}