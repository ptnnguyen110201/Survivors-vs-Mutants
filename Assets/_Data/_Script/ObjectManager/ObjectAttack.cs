using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAttack<T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;
    [SerializeField] protected float coolDownTime;
    [SerializeField] protected float coolDownTimer;
    [SerializeField] protected bool canAttack = false;
    public abstract void Attacking();

    protected virtual bool IsCanAttack() 
    {
        this.coolDownTimer += Time.deltaTime;
        if (this.coolDownTime > this.coolDownTimer) return true;
        this.coolDownTimer = 0;
        return false;
    }
    public virtual void SetCoolDownTime(float coolDownTime) => this.coolDownTime = coolDownTime;
    public virtual void SetCoolDownTimer(float coolDownTimer) => this.coolDownTimer = coolDownTimer;
    public virtual void SetCanAttack(bool canAttack) => this.canAttack = canAttack;
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
