using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : ObjectCtrl<CharacterCtrl>
{
    [Header("Lane")] protected int lane;
    public int Lane => lane;
    [SerializeField] protected bool isGround = false;
    public bool IsGround => isGround;

    [Header("Enemy Ctrl")]
    [SerializeField] protected ObjectTargeting<CharacterCtrl> objectTargeting;
    public ObjectTargeting<CharacterCtrl> ObjectTargeting => objectTargeting;

    [SerializeField] protected ObjectAttack<CharacterCtrl> objectAttack;
    public ObjectAttack<CharacterCtrl> ObjectAttack => objectAttack;

    [SerializeField] protected EnemyDamageReceiver enemyDamageReceiver;
    public EnemyDamageReceiver EnemyDamageReceiver => enemyDamageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectTargeting();
        this.LoadObjectAttack();
        this.LoadCharacterDamageReceiver();
    }
    protected virtual void OnEnable()
    {
        CharacterManager characterManager = FindAnyObjectByType<CharacterManager>();
        if (characterManager == null) return;
        characterManager.RegisterObject(this);
    }

    protected virtual void LoadObjectAttack()
    {
        if (this.objectAttack != null) return;
        this.objectAttack = transform.GetComponentInChildren<ObjectAttack<CharacterCtrl>>();
        Debug.Log(transform.name + ": Load ObjectAttack ", gameObject);
    }

    protected virtual void LoadObjectTargeting()
    {
        if (this.objectTargeting != null) return;
        this.objectTargeting = transform.GetComponentInChildren<ObjectTargeting<CharacterCtrl>>();
        Debug.Log(transform.name + ": Load ObjectTargeting ", gameObject);
    }

    protected virtual void LoadCharacterDamageReceiver()
    {
        if (this.enemyDamageReceiver != null) return;
        this.enemyDamageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.Log(transform.name + ": Load EnemyDamageReceiver ", gameObject);
    }


    public virtual void SetLane(int Lane ) => this.lane = Lane;
}
