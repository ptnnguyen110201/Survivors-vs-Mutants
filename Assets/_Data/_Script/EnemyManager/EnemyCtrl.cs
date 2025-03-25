using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjectCtrl<EnemyCtrl>
{
    [Header("Lane")]
    [SerializeField] protected int lane;
    public int Lane => lane;

    [SerializeField] protected bool isEnable = true;
    public bool IsEnable => isEnable;
    public virtual void SetEnableEnemy(bool isEnable) => this.isEnable = isEnable;
    [Header("Enemy Ctrl")]
    [SerializeField] protected CircleCollider2D circleCollider2D;
    public CircleCollider2D CircleCollider2D => circleCollider2D;

    [SerializeField] protected ObjectTargeting<EnemyCtrl> objectTargeting;
    public ObjectTargeting<EnemyCtrl> ObjectTargeting => objectTargeting;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

	[SerializeField] protected EnemyAttack enemyAttack;
	public EnemyAttack EnemyAttack => enemyAttack;

    [SerializeField] protected EnemyHPSlider enemyHPSlider;
    public EnemyHPSlider EnemyHPSlider => enemyHPSlider;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectTargeting();
        this.LoadObjectAttack();
        this.LoadEnemyDamageReceiver();
        this.LoadCircleCollider2D();
       
       this.LoadEnemyHPSlider();
    }
    protected virtual void OnEnable()
    {

		EnemyProfile enemyProfile = this.objectProfile as EnemyProfile;
		this.enemyDamageReceiver.SetMaxHp(enemyProfile.enemyAttributes.attributes.maxHP);
		this.enemyAttack.SetDamage(enemyProfile.enemyAttributes.attributes.attackDamage);
		this.enemyAttack.SetCoolDownTimer(enemyProfile.enemyAttributes.attributes.fireRate);
		this.objectMove.SetMoveSpeed(enemyProfile.enemyAttributes.attributes.moveSpeed);
	}

    protected virtual void LoadObjectAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = transform.GetComponentInChildren<EnemyAttack>();
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
    protected virtual void LoadEnemyHPSlider()
    {
        if (this.enemyHPSlider != null) return;
        this.enemyHPSlider = transform.GetComponentInChildren<EnemyHPSlider>(true);
        Debug.Log(transform.name + ":Load EnemyHPSlider ", gameObject);
    }
 
    public virtual void SetLane(int Lane) => this.lane = Lane;
}
