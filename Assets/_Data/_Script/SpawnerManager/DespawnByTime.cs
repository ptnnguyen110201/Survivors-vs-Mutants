using System.Collections;
using UnityEngine;

public class DespawnByTime<T> : Despawn<T> where T : PoolObj

{
    [SerializeField] protected float timeLife;
    [SerializeField] protected float timer;

    public virtual void Timing() 
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.timeLife) return;
        this.timer = 0f;
        this.DespawnObj();
    }
   
}
