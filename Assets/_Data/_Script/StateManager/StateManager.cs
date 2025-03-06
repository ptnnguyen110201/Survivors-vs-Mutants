using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<T> T_List;

    public virtual void RegisterObject(T Object) 
    {
        if (Object is not MonoBehaviour) return;
        if (this.T_List.Contains(Object)) return;
        this.T_List.Add(Object);
    }


    public virtual void UnRegisterObject(T Object)
    {
        if (Object is not MonoBehaviour) return;
        if (!this.T_List.Contains(Object)) return;
        this.T_List.Remove(Object);
    }

}
