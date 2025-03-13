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
        Screen.SetResolution(1920, 1080, true);
        Application.targetFrameRate = 1000;
    }


    protected virtual void Reset()
    {
        this.ResetValue();
        this.LoadComponents();
    }


}
