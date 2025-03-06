using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadComPonent : MonoBehaviour
{
    protected virtual void LoadComponents()
    {
        // For Override 
    }    
    protected virtual void ResetValue()
    {
        // For Override 
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }


    protected virtual void Reset()
    {
        this.ResetValue();
        this.LoadComponents();
    }


}
