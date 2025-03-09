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
            if (!bulletCtrl.gameObject.activeSelf) return;
            bulletCtrl.ObjectMove.Moving();
        }
    }
}
