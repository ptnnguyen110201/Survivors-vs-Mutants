using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMove <T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;
    [SerializeField] protected float moveSpeed; 
    [SerializeField] protected Vector3 moveDirection;

    public abstract void Moving();
    
    public virtual void SetMoveSpeed(float moveSpeed ) => this.moveSpeed = moveSpeed;
    public virtual void SetMoveDirection(Vector3 moveDirection) => this.moveDirection = moveDirection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
    }
    protected virtual void LoadObjParent() 
    {
        if (this.ObjParent != null) return;
        this.ObjParent = transform.GetComponentInParent<T>();
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }
}
