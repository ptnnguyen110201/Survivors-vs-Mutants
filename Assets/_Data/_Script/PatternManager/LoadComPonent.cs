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
        Screen.fullScreen = true;
        Application.targetFrameRate = 120;
    }


    protected virtual void Reset()
    {
        this.ResetValue();
        this.LoadComponents();
    }
    protected void LoadScript<T>(ref T script, GameObject obj) where T : class
    {
        if (script != null)
            return;
        script = obj.GetComponent<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    protected void LoadScript<T>(ref T script, Transform obj) where T : class
    {
        if (script != null)
            return;
        script = obj.GetComponent<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    protected void LoadScript<T>(ref T script) where T : class
    {
        if (script != null)
            return;
        script = gameObject.GetComponent<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    protected void LoadScriptInChild<T>(ref T script) where T : class
    {
        if (script != null)
            return;
        script = gameObject.GetComponentInChildren<T>();
        DebugLoadComponent(typeof(T).Name);
    }

    private void DebugLoadComponent(string nameComponent)
    {
        Debug.LogWarning("Load Script " + nameComponent, gameObject);
    }



}
