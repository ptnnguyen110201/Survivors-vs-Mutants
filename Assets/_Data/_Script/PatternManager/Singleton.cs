using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : LoadComPonent where T : MonoBehaviour
{
    private static T instance; 
    public static T Instance => instance;
 

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance() 
    {
        if(instance == null) 
        {
            instance = this as T;
            return;
        }
        if (instance != this) Debug.LogError("Another instance of Singleton already exist!");
        
            
        
    }
}
