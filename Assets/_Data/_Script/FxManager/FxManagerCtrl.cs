using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManagerCtrl : Singleton<FxManagerCtrl>
{
    [SerializeField] protected FxManager fxManager;
    public FxManager FxManager => fxManager;

    [SerializeField] protected FxSpawner fxSpawner;
    public FxSpawner FxSpawner => fxSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFxManager();
        this.LoadFxSpawner();
    }

    protected virtual void LoadFxManager()
    {
        if (this.fxManager != null) return;
        this.fxManager = transform.GetComponent<FxManager>();
        Debug.Log(transform.name + ": Load FxManager", gameObject);
    }

    protected virtual void LoadFxSpawner()
    {
        if (this.fxSpawner != null) return;
        this.fxSpawner = transform.GetComponentInChildren<FxSpawner>(true);
        Debug.Log(transform.name + ": Load FxSpawner", gameObject);
    }
}
