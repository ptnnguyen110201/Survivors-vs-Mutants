using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyWaveSpawning : LoadComPonent
{
    [SerializeField] protected int currentWaveIndex = 0;
    [SerializeField] protected bool isSpawning = false;


    protected void Update()
    {
        this.SpawnWave();
    }
  
    protected void SpawnWave()
    {
        if (!GameManager.Instance.IsStart) return;
        if (this.isSpawning) return;
        if (this.currentWaveIndex >= this.GetMapCtrl().MapProfile.mapWaves.Count) return;
        if (this.GetAlivesEnemy() > 0) return;
        this.StartCoroutine(this.SpawnWaveEnemy());
    }

    protected IEnumerator SpawnWaveEnemy()
    {
        this.isSpawning = true;
        yield return new WaitForSeconds(this.GetMapCtrl().MapProfile.timeBeforeFirstWave);

        MapWave currentWave = this.GetMapCtrl().MapProfile.mapWaves[this.currentWaveIndex];

        foreach (MapEnemyInfo mapEnemyInfo in currentWave.mapEnemyInfos)
        {
            for (int i = 0; i < mapEnemyInfo.count; i++)
            {
                EnemyManagerCtrl.Instance.EnemySpawner.SpawnEnemy(mapEnemyInfo.enemyProfile);
                yield return new WaitForSeconds(mapEnemyInfo.delay);
            }
        }
        this.currentWaveIndex++;
        this.isSpawning = false;
        yield return new WaitForSeconds(currentWave.waitBetweenWaves);
    }

  
    protected MapCtrl GetMapCtrl() => MapManager.Instance.CurrentMap;
    protected int GetAlivesEnemy()
    {
        int count = 0;
        foreach (EnemyCtrl enemyCtrl in EnemyManagerCtrl.Instance.EnemyManager.T_ListObj)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead()) continue;
            count += 1;

        }
        return count;
    }

  
}
