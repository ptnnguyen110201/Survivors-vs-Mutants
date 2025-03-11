using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectDamageSender : LoadComPonent
{
    [SerializeField] protected int damage = 1;
    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        ObjectDamageReciever damageReceiver = collider2D.GetComponentInChildren<ObjectDamageReciever>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    protected virtual void Send(ObjectDamageReciever damageReceiver) => damageReceiver.Deduct(this.damage);
    
    public virtual void SetDamage(int damage) => this.damage = damage;
}
