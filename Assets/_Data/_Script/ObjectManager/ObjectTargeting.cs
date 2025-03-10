using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectTargeting<T> : LoadComPonent 
{
    [SerializeField] protected T objParent;
    [SerializeField] protected Transform objTargeting;
    public virtual void SetObjTargeting(Transform objTargeting) => this.objTargeting = objTargeting;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
    }
    public abstract void CheckTargeting();
    protected virtual void LoadObjParent()
    {
        if (this.objParent != null) return;
        this.objParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

 
}
