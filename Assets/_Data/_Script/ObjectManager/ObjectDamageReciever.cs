using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectDamageReciever<T> : LoadComPonent
{
    [SerializeField] protected T objParent;
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int currentHp = 10;
    [SerializeField] protected bool isDead = false;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual int Deduct(int Hp)
    {
        this.currentHp -= Hp;
        if (this.IsDead()) this.OnDead();
        
        if (this.currentHp < 0) this.currentHp = 0;
        return this.currentHp;
    }

    public virtual bool IsDead() => this.isDead = this.currentHp <= 0;
    protected virtual void OnDead()
    {
        //for override
    }

    protected virtual void Reborn()
    {
        this.currentHp = this.maxHp;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
    }
    protected virtual void LoadObjParent()
    {
        if (this.objParent != null) return;
        this.objParent = transform.GetComponentInParent<T>();
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }





}
