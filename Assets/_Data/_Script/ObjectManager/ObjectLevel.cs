using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectLevel<T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;
    [SerializeField] protected int currentLevel;
    [SerializeField] protected int maxLevel;
    protected virtual void OnEnable()
    {
        this.GetCurrentLevel();
        this.GetMaxLevel();

    }
    public abstract void levelUp();
    public abstract int GetMaxLevel();
    public abstract int GetCurrentLevel();
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
