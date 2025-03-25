using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSpawner : Spawner<FxCtrl>
{

    public virtual FxCtrl SpawnFx(string FxName, Vector3 spawnPos)
    {
        FxCtrl fxCtrl = this.PoolPrefabs.GetPrefabByName(FxName);
        if (fxCtrl == null) return null;

        FxCtrl newFx = this.Spawn(fxCtrl, spawnPos);
        FxManagerCtrl.Instance.FxManager.RegisterObject(newFx);
        return newFx;
    }

}
