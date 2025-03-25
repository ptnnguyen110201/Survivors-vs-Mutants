using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner<BulletCtrl>
{

    public virtual BulletCtrl SpawnBullet(string BulletName, Vector3 spawnPos)
    {
        BulletCtrl bulletCtrl = this.PoolPrefabs.GetPrefabByName(BulletName);
        if (bulletCtrl == null) return null;
        BulletCtrl newFx = this.Spawn(bulletCtrl, spawnPos);
        BulletManagerCtrl.Instance.BulletManager.RegisterObject(newFx);
        return newFx;
    }

}



