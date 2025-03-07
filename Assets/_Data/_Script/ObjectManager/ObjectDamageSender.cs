using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public abstract class ObjectDamageSender<T> : LoadComPonent
{
    [SerializeField] protected float damageDelay;
    [SerializeField] protected int damage;
    [SerializeField] protected CircleCollider2D circleCollider2D;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": Load CircleCollider2D", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D  collider2D)
    {
        ObjectDamageReciever<T> damageReceiver = collider2D.GetComponentInChildren<ObjectDamageReciever<T>>();
        if (damageReceiver == null) return;
        this.StartCoroutine(this.SendCoroutine(damageReceiver));
        
    }
    public virtual void Send(ObjectDamageReciever<T> damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    protected virtual IEnumerator SendCoroutine(ObjectDamageReciever<T> damageReceiver)
    {
        
        yield return new WaitForSeconds(this.damageDelay);
        this.Send(damageReceiver);
    }

    public void SetActiveCollider(bool active) => this.circleCollider2D.enabled = active;
    public virtual void SetDamage(int damage) => this.damage = damage;
    public virtual void SetDamageDelay(float damageDelay) => this.damageDelay = damageDelay;
}
