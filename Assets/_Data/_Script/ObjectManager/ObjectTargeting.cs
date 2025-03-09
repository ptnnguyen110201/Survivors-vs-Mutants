using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public abstract class ObjectTargeting<T> : LoadComPonent 
{
    [SerializeField] protected T objParent;
    [SerializeField] protected CircleCollider2D circleCollider2;
    [SerializeField] protected Transform objTargeting;
    public virtual void SetObjTargeting(Transform objTargeting) => this.objTargeting = objTargeting;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
        this.LoadCircleCollider2D();
    }
    public abstract void CheckTargeting();
    protected virtual void LoadObjParent()
    {
        if (this.objParent != null) return;
        this.objParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2 != null) return;
        this.circleCollider2 = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": Load CircleCollider2D", gameObject);
    }
}
