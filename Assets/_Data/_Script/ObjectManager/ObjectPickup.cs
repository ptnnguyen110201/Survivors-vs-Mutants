using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ObjectPickup<T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;

    protected abstract void OnPointerDown();

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
