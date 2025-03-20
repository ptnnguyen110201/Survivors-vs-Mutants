using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAttributes<T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;
    [SerializeField] protected Attributes attributes;
    public Attributes Attributes => attributes; 
    protected virtual void OnEnable() 
    {

        this.GetAttributes();  
        this.SetAttribute();
    }

    public abstract void GetAttributes();
    public abstract void SetAttribute();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
    }
    protected virtual void LoadObjParent()
    {
        if (this.ObjParent != null) return;
        this.ObjParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }


}
