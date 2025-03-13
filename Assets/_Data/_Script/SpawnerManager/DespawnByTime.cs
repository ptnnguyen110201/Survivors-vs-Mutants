using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DespawnByTime<T> : Despawn<T> where T : PoolObj

{
    [SerializeField] protected float timeLife;
    public virtual void SetTimeLife(float timeLife ) => this.timeLife = timeLife;
    protected override IEnumerator DespawnCoroutine()
    {
        yield return new WaitForSeconds(this.timeLife);
        this.DespawnObj();
    }
}
