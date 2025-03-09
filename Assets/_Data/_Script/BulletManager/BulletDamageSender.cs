using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletDamageSender : ObjectDamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected override void Send(ObjectDamageReciever damageReceiver)
    {
        base.Send(damageReceiver);
        this.Despawn();
    }
    protected virtual void Despawn() 
    {
        this.bulletCtrl.DespawnBase.DespawnObj();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.GetComponentInParent<BulletCtrl>(true);
        Debug.Log(transform.name + ": Load BulletCtrl ", gameObject);
    }

}
