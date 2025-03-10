using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectDamageReciever: LoadComPonent
{
    [SerializeField] protected int maxHp = 10;
    [SerializeField] protected int currentHp = 10;
    [SerializeField] protected bool isDead = false;

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
    

}
