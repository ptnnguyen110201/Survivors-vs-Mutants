using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjectCtrl<EnemyCtrl>
{

    protected virtual void OnEnable()
    {
        EnemyManager enemyStateManager = FindAnyObjectByType<EnemyManager>();
        if (enemyStateManager == null) return;
        enemyStateManager.RegisterObject(this);
    }
}
