using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DespawnByDistance<T> : Despawn<T> where T : PoolObj

{
    [SerializeField] protected Camera mainCam;
    [SerializeField] protected float maxDespawnDistance = 15f;
    public virtual void SetTimeLife(float maxDespawnDistance) => this.maxDespawnDistance = maxDespawnDistance;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCam();
    }

    protected virtual void LoadMainCam()
    {
        if (this.mainCam != null) return;
        this.mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Debug.Log(transform.name + "Load MainCam", gameObject);

    }


    public virtual void DespawnByDist() 
    {

        float distance = Vector3.Distance(this.parent.transform.position, this.mainCam.transform.position);
        if (distance < this.maxDespawnDistance) return;
        base.DespawnObj();
    }
}
