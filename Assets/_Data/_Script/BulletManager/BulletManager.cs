using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : ObjectManager<BulletCtrl>
{
    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (BulletCtrl bulletCtrl in this.T_List)
        {
            if (!bulletCtrl.gameObject.activeSelf) continue;
            bulletCtrl.ObjectMove.Moving();

            BulletDespawn bulletDespawn = bulletCtrl.DespawnBase as BulletDespawn;
            if (bulletDespawn == null) continue;
            bulletDespawn.DespawnByDist();
        }
    }




}
