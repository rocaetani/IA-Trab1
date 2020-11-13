using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Spot : MonoBehaviour
{

    public int Position;

    public GameObject CrossObjectRoot;
    public GameObject CirculeObjectRoot;
    
    public Symbol _currentSymbol;

    public Symbol CurrentSymbol
    {
        set
        {
            _currentSymbol = value;
            CrossObjectRoot.SetActive(_currentSymbol == Symbol.Cross);
            CirculeObjectRoot.SetActive(_currentSymbol == Symbol.Circle);
            
        }
        get { return _currentSymbol; }
    }

    private void Start()
    {
        CurrentSymbol = Symbol.None;
    }


    public void OnMouseDown()
    {
        GetComponentInParent<BoardController>().SpotClicked(this);
    }
    
    


}
