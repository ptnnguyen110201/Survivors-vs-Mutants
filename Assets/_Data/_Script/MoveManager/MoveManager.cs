using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveManager : Singleton<MoveManager>
{
    [SerializeField] protected List<MoveBase> moveBases;
    protected override void LoadComponents() 
    {
        foreach (Transform obj in transform)
        {
            MoveBase moveBase = obj.GetComponent<MoveBase>();
            this.moveBases.Add(moveBase);
        }
    }
    protected virtual void Update() 
    {
        foreach (MoveBase obj in moveBases)
        {
            obj.Moving();
        }
    }
}
