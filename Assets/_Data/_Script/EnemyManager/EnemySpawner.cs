using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<EnemyCtrl>
{

    protected void Start()
    {

        InvokeRepeating(nameof(this.SpawnEnemy), 1, 1);
    }
    public virtual void SpawnEnemy()
    {
        EnemyCtrl enemyCtrl = this.poolPrefabs.GetPrefabByName("Enemy");
        if (enemyCtrl == null) return;
        PathMap pathMap = MapManager.Instance.CurrentMap.PathManager.GetRandomPathMap();
        EnemyCtrl newEnemy = this.Spawn(enemyCtrl, pathMap.GetSpawnPoint());

        EnemyMove enemyMove = (EnemyMove)newEnemy.ObjectMove;
        enemyMove.SetPathMap(pathMap);

        newEnemy.gameObject.SetActive(true);

    }

}
