using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManagerCtrl : Singleton<ItemsDropManagerCtrl>
{
    [SerializeField] protected ItemDropSpanwer itemDropSpanwer;
    public ItemDropSpanwer ItemDropSpanwer => itemDropSpanwer;

    [SerializeField] protected ItemDropManager itemDropManager;
    public ItemDropManager ItemDropManager => itemDropManager;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropSpawner();
        this.LoadItemDropManager();
    }

    protected virtual void LoadItemDropSpawner() 
    {
        if (this.itemDropSpanwer != null) return;
        this.itemDropSpanwer = transform.GetComponentInChildren<ItemDropSpanwer>();
        Debug.Log(transform.name + ": Load ItemDropSpawner");
    }

    protected virtual void LoadItemDropManager()
    {
        if (this.itemDropManager != null) return;
        this.itemDropManager = transform.GetComponent<ItemDropManager>();
        Debug.Log(transform.name + ": Load ItemDropManager");
    }


}
