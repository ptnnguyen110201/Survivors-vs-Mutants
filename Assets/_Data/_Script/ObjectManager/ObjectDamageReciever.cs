using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectDamageReciever : LoadComPonent
{
    [SerializeField] protected int maxHp;
    [SerializeField] protected int currentHp;
    [SerializeField] protected bool isDead = false;

    public int MaxHP => maxHp;
    public int CurrentHp => currentHp;

    [SerializeField] protected ObjectAnimationEnum objectAnimationEnum;
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
        this.isDead = false;
    }

    public virtual void SetMaxHp(int maxHp)
    {
        this.currentHp = maxHp;
        this.maxHp = maxHp;
    }
}
