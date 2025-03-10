using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ObjectManager<EnemyCtrl>
{
    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (EnemyCtrl enemy in this.T_List)
        {
            if (!enemy.gameObject.activeSelf) continue;
            enemy.ObjectTargeting.CheckTargeting();
            enemy.ObjectMove.Moving();
            enemy.ObjectAttack.Attacking();

        }
    }
}
