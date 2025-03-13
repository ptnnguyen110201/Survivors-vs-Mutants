using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T : PoolObj
{
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected Coroutine despawnCoroutine;

    protected virtual void OnDisable()
    {
        if (this.despawnCoroutine != null)
        {
            this.StopCoroutine(this.despawnCoroutine);
            this.despawnCoroutine = null;
            return;
        }
    }
    protected virtual void OnEnable()
    {
        if(this.despawnCoroutine != null) 
        {
            this.StopCoroutine(this.despawnCoroutine);
            this.despawnCoroutine = this.StartCoroutine(this.DespawnCoroutine());
            return;

        }
        this.despawnCoroutine = this.StartCoroutine(this.DespawnCoroutine());

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParent();
        this.LoadSpawner();
    }

    protected virtual void LoadParent() 
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + "Load Parent", gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GameObject.FindAnyObjectByType<Spawner<T>>();
        Debug.Log(transform.name + "LoadSpawner", gameObject);
    }

    public override void DespawnObj() 
    {
        this.spawner.Despawn(this.parent);
    }

    protected abstract IEnumerator DespawnCoroutine();

    

    
}
