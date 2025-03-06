using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectDamageSender<T> : LoadComPonent 
{
    [SerializeField] protected int damage;


    public virtual void Send() 
    {
        //for override 
    }
    public virtual void SetDamage(int damage) => this.damage = damage;
}
