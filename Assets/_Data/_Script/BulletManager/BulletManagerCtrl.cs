using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManagerCtrl : Singleton<BulletManagerCtrl>
{
    [SerializeField] protected BulletManager bulletManager;
    public BulletManager BulletManager => bulletManager;

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletManager();
        this.LoadBulletSpawner();
    }

    protected virtual void LoadBulletManager()
    {
        if (this.bulletManager != null) return;
        this.bulletManager = transform.GetComponent<BulletManager>();
        Debug.Log(transform.name + ": Load BulletManager", gameObject);
    }

    protected virtual void LoadBulletSpawner()
    {
        if (this.bulletSpawner != null) return;
        this.bulletSpawner = transform.GetComponentInChildren<BulletSpawner>(true);
        Debug.Log(transform.name + ": Load BulletSpawner", gameObject);
    }
}
