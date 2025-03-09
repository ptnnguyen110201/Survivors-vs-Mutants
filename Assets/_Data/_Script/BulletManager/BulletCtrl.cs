using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ObjectCtrl<BulletCtrl>
{
    [Header("Bullet Ctrl")]
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;
    protected virtual void OnEnable()
    {
        BulletManager bulletManager = FindAnyObjectByType<BulletManager>();
        if (bulletManager == null) return;
        bulletManager.RegisterObject(this);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDamageSender();
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ": Load BulletDamageSender", gameObject);
    }

}
