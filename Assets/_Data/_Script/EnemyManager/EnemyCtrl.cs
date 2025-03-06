using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjectCtrl<EnemyCtrl>
{
    
    protected virtual void OnEnable() 
    {
        EnemyStateManager enemyStateManager = FindAnyObjectByType<EnemyStateManager>();
        if (enemyStateManager == null) return;
        enemyStateManager.RegisterObject(this);
    }
}
