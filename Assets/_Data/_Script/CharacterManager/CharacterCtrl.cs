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

    [SerializeField] protected CharacterAttack characterAttack;
    public CharacterAttack CharacterAttack => characterAttack;

    [SerializeField] protected CharacterDamageReceiver characterDamageReceiver;
    public CharacterDamageReceiver CharacterDamageReceiver => characterDamageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectTargeting();
        this.LoadCharacterAttack();
        this.LoadCharacterDamageReceiver();
    }
    protected virtual void OnEnable()
    {
        CharacterManagerCtrl.Instance.CharacterManager.RegisterObject(this);

        CharacterProfile characterProfile = this.objectProfile as CharacterProfile;
        this.characterDamageReceiver.SetMaxHp(characterProfile.maxHP);
        this.characterAttack.SetDamage(characterProfile.attackDamage);
        this.characterAttack.SetCoolDownTimer(characterProfile.fireRate);
        this.objectMove.SetMoveSpeed(characterProfile.moveSpeed);
    }

    protected virtual void LoadCharacterAttack()
    {
        if (this.characterAttack != null) return;
        this.characterAttack = transform.GetComponentInChildren<CharacterAttack>();
        Debug.Log(transform.name + ": Load CharacterAttack ", gameObject);
    }

    protected virtual void LoadObjectTargeting()
    {
        if (this.objectTargeting != null) return;
        this.objectTargeting = transform.GetComponentInChildren<ObjectTargeting<CharacterCtrl>>();
        Debug.Log(transform.name + ": Load ObjectTargeting ", gameObject);
    }

    protected virtual void LoadCharacterDamageReceiver()
    {
        if (this.characterDamageReceiver != null) return;
        this.characterDamageReceiver = transform.GetComponentInChildren<CharacterDamageReceiver>();
        Debug.Log(transform.name + ": Load CharacterDamageReceiver ", gameObject);
    }


    public virtual void SetLane(int Lane ) => this.lane = Lane;
}
