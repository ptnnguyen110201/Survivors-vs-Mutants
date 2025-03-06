using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : StateManager<EnemyCtrl>
{
    protected virtual void FixedUpdate() 
    {
        this.EnemyEffecing();
    }
   protected virtual void EnemyEffecing() 
   {
        foreach(EnemyCtrl enemyCtrl in this.T_List) 
        {
            enemyCtrl.ObjectModel.ApplyEffect();
            enemyCtrl.ObjectMove.Moving();
            enemyCtrl.ObjectAttack.Attacking();
        }
   }
}
