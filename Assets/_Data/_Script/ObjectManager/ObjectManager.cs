using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectManager<T> : LoadComPonent where T : MonoBehaviour 
{
    [SerializeField] protected List<T> T_List;

    public virtual void RegisterObject(T Object)
    {
        if (Object is not MonoBehaviour) return;
        if (T_List.Contains(Object)) return;
        this.T_List.Add(Object);
    }


    public virtual void UnRegisterObject(T Object)
    {
        if (Object is not MonoBehaviour) return;
        if (!T_List.Contains(Object)) return;
        this.T_List.Remove(Object);
    }

}
