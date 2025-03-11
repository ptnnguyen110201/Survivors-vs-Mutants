using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAttack<T> : LoadComPonent
{
    [SerializeField] protected T ObjParent;
    [SerializeField] protected float coolDownTime;
    [SerializeField] protected float coolDownTimer;
    [SerializeField] protected bool canAttack = false;
    [SerializeField] protected Transform attackPoint;

    [SerializeField] protected ObjectAnimationEnum objectAnimationEnum;
    public abstract void Attacking();

    protected virtual bool IsCanAttack() 
    {
        this.coolDownTimer += Time.deltaTime;
        if (this.coolDownTimer < this.coolDownTime) return false;
        this.coolDownTimer = 0;
        return true;
    }
    public virtual void SetCoolDownTime(float coolDownTime) => this.coolDownTime = coolDownTime;
    public virtual void SetCoolDownTimer(float coolDownTimer) => this.coolDownTimer = coolDownTimer;
    public virtual void SetCanAttack(bool canAttack) => this.canAttack = canAttack;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjParent();
        this.LoadAttackPoint();
    }
    protected virtual void LoadObjParent() 
    {
        if (this.ObjParent != null) return;
        this.ObjParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = transform.Find("AttackPoint").GetComponent<Transform>() ;
        this.ObjParent = transform.GetComponentInParent<T>(true);
        Debug.Log(transform.name + ": Load ObjParent", gameObject);
    }
}
