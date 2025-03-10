using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjectCtrl<EnemyCtrl>
{
    [Header("Enemy Ctrl")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    public CircleCollider2D CircleCollider2D => circleCollider2D;

    [SerializeField] protected ObjectTargeting<EnemyCtrl> objectTargeting;
    public ObjectTargeting<EnemyCtrl> ObjectTargeting => objectTargeting;

    [SerializeField] protected ObjectAttack<EnemyCtrl> objectAttack;
    public ObjectAttack<EnemyCtrl> ObjectAttack => objectAttack;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectTargeting();
        this.LoadObjectAttack();
        this.LoadEnemyDamageReceiver();
        this.LoadCircleCollider2D();
    }
    protected virtual void OnEnable()
    {
        EnemyManager enemyStateManager = FindAnyObjectByType<EnemyManager>();
        if (enemyStateManager == null) return;
        enemyStateManager.RegisterObject(this);
    }

    protected virtual void LoadObjectAttack()
    {
        if (this.objectAttack != null) return;
        this.objectAttack = transform.GetComponentInChildren<ObjectAttack<EnemyCtrl>>();
        Debug.Log(transform.name + ": Load ObjectAttack ", gameObject);
    }

    protected virtual void LoadObjectTargeting()
    {
        if (this.objectTargeting != null) return;
        this.objectTargeting = transform.GetComponentInChildren<ObjectTargeting<EnemyCtrl>>();
        Debug.Log(transform.name + ": Load ObjectTargeting ", gameObject);
    }

    protected virtual void LoadEnemyDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": Load EnemyDamageReceiver ", gameObject);
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        Debug.Log(transform.name + ": Load CircleCollider2D ", gameObject);
    }

}
