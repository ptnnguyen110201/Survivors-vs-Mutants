using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<EnemyCtrl>
{

    public virtual void SpawnEnemy(EnemyProfile enemyProfile)
    {
        EnemyCtrl enemyCtrl = this.poolPrefabs.GetPrefabByName(enemyProfile.enemyName);
        if (enemyCtrl == null) return;

        PathMap pathMap = MapManager.Instance.CurrentMap.PathManager.GetRandomPathMap();
        EnemyCtrl newEnemy = this.Spawn(enemyCtrl, pathMap.GetSpawnPoint());
        newEnemy.SetLane(pathMap.GetMapLane());

        EnemyMove enemyMove = (EnemyMove)newEnemy.ObjectMove;
        enemyMove.SetPathMap(pathMap);

        newEnemy.SetEnableEnemy(true);
        EnemyManagerCtrl.Instance.EnemyManager.RegisterObject(newEnemy);
        newEnemy.gameObject.SetActive(true);

   
    }
    public virtual EnemyCtrl SpawnPreviewEnemy(EnemyProfile enemyProfile, Vector3 spawnPoint)
    {
        EnemyCtrl enemyCtrl = this.poolPrefabs.GetPrefabByName(enemyProfile.enemyName);
        if (enemyCtrl == null) return null;

        EnemyCtrl newEnemy = this.Spawn(enemyCtrl, spawnPoint);
        newEnemy.SetEnableEnemy(false);
        newEnemy.gameObject.SetActive(true);

        return newEnemy;

    }
}
