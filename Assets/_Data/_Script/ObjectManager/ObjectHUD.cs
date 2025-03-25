using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectHUD<T> : LoadComPonent where T : class
{

    [SerializeField] protected T ObjParent;

    public virtual void ShowFushionIMG(bool canFushion)
    {
        
    }

    protected override void LoadComponents()
    {
        this.LoadObjParent();
    }
    protected virtual void LoadObjParent()
    {
        if (this.ObjParent != null) return;
        this.ObjParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

}
