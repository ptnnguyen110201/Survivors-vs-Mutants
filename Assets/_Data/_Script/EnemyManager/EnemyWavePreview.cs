using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyWavePreview : LoadComPonent
{

    [SerializeField] protected List<Transform> enemyWavePreviews;
    [SerializeField] protected List<EnemyCtrl> enemyPreviews;
    [SerializeField] protected bool spawned = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPreviewPoint();
    }
    protected virtual void LoadPreviewPoint()
    {
        if (this.enemyWavePreviews.Count > 0) return;
        foreach (Transform point in this.transform)
        {
            if (point == null) continue;
            this.enemyWavePreviews.Add(point);
        }
        Debug.Log(transform.name + "Load PreviewPoint", gameObject);
    }
    protected void Update()
    {

        this.SpawnPreview();
    }
    protected virtual void SpawnPreview() 
    {
        if (GameManager.Instance.IsStart) 
        {
            this.Invoke(nameof(this.ClearEnemy), 2f);
            return;
        }
        if (this.spawned) return;
        this.StartCoroutine(SpawnWavePreviewEnemy());
    }

    protected IEnumerator SpawnWavePreviewEnemy()
    {
        this.spawned = true;
        foreach (MapWave mapWave in this.GetMapCtrl().MapProfile.mapWaves)
        {
            foreach(MapEnemyInfo mapEnemyInfo in mapWave.mapEnemyInfos) 
            {
                Vector3 spawnPos = this.RandomPos().transform.position;
                EnemyCtrl previewEnemy = EnemyManagerCtrl.Instance.EnemySpawner.SpawnPreviewEnemy(mapEnemyInfo.enemyProfile, spawnPos);
                this.enemyPreviews.Add(previewEnemy);
            }
            yield return new WaitForSeconds(0);
        }
        yield break;
        
    }
    protected virtual void ClearEnemy() 
    {
        if (this.enemyPreviews.Count <= 0) return;
        foreach(EnemyCtrl enemyCtrl in this.enemyPreviews) 
        {
            enemyCtrl.DespawnBase.DespawnObj();
        }
        this.enemyPreviews.Clear();
    }
    protected MapCtrl GetMapCtrl() => MapManager.Instance.CurrentMap;

    protected Transform RandomPos() 
    {
        int index = Random.Range(0, this.enemyWavePreviews.Count);
        return this.enemyWavePreviews[index];
    }
}
