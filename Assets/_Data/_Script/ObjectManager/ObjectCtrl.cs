using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCtrl<T> : PoolObj 
{

    [Header("Object Profile")]
    [SerializeField] protected ObjectProfile objectProfile;
    public ObjectProfile ObjectProfile => objectProfile;

    [Header("Object Base Ctrl")]

    [SerializeField] protected ObjectAnimator<T> objectAnimator;
    public ObjectAnimator<T> ObjectAnimator => objectAnimator;

    [SerializeField] protected ObjectModel<T> objectModel;
    public ObjectModel<T> ObjectModel => objectModel;

    [SerializeField] protected ObjectMove<T> objectMove;
    public ObjectMove<T> ObjectMove => objectMove; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAnimator();
        this.LoadObjectMove();
        this.LoadObjectModel();
    }
    protected virtual void LoadObjectAnimator()
    {
        if (this.objectAnimator != null) return;
        this.objectAnimator = transform.GetComponentInChildren<ObjectAnimator<T>>();
        Debug.Log(transform.name + ": Load ObjectAnimator ", gameObject);
    }
    protected virtual void LoadObjectModel()
    {
        if (this.objectModel != null) return;
        this.objectModel = transform.GetComponentInChildren<ObjectModel<T>>();
        Debug.Log(transform.name + ": Load ObjectModel ", gameObject);
    }
    protected virtual void LoadObjectMove() 
    {
        if (this.objectMove != null) return;
        this.objectMove = transform.GetComponentInChildren<ObjectMove<T>>();
        Debug.Log(transform.name + ": Load ObjectMove ", gameObject);
    }

}
