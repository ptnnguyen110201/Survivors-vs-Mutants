using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerCtrl : Singleton<EnemyManagerCtrl>
{
    [SerializeField] protected EnemyManager enemyManager;
    public EnemyManager EnemyManager => enemyManager;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManager();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemyManager()
    {
        if (this.enemyManager != null) return;
        this.enemyManager = transform.GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": Load EnemyManager", gameObject);
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = transform.GetComponentInChildren<EnemySpawner>(true);
        Debug.Log(transform.name + ": Load EnemySpawner", gameObject);
    }
}
