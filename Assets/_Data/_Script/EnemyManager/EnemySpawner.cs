using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<EnemyCtrl>
{
 
    protected virtual void Start() 
    {
       InvokeRepeating( nameof(this.SpawnEnemy),0.1f,1f);
    }
    protected virtual void SpawnEnemy() 
    {
        EnemyCtrl enemyCtrl = this.poolPrefabs.GetPrefabByName("Enemy");
        if (enemyCtrl == null) return;
        Vector3 spawnPos = new Vector3(11, 0, -1);
        EnemyCtrl newEnemy = this.Spawn(enemyCtrl, spawnPos);
        newEnemy.gameObject.SetActive(true);
        
    }

}
