using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ObjectCtrl<BulletCtrl>
{
    [Header("Bullet Ctrl")]
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDamageSender();
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>(true);
        Debug.Log(transform.name + ": Load BulletDamageSender", gameObject);
    }

}
