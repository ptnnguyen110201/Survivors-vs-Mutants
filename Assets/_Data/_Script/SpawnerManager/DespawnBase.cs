using UnityEngine;

public abstract class DespawnBase : LoadComPonent
{
    [SerializeField] protected bool isDespawnByTime = false;
    [SerializeField] protected bool isDespawnByDistance = false;
    public abstract void DespawnObj();
}
