using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCtrl <T> : LoadComPonent 
{
    [SerializeField] protected ObjectModel<T> objectModel;
    public ObjectModel<T> ObjectModel => objectModel;
    [SerializeField] protected ObjectMove<T> objectMove;
    public ObjectMove<T> ObjectMove => objectMove;

    [SerializeField] protected ObjectAttack<T> objectAttack;
    public ObjectAttack<T> ObjectAttack => objectAttack;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectMove();
        this.LoadObjectAttack();
        this.LoadObjectModel();
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

    protected virtual void LoadObjectAttack()
    {
        if (this.objectAttack != null) return;
        this.objectAttack = transform.GetComponentInChildren<ObjectAttack<T>>();
        Debug.Log(transform.name + ": Load ObjectAttack ", gameObject);
    }
}
