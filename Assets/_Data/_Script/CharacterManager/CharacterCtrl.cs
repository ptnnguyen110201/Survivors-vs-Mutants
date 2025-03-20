using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCtrl : ObjectCtrl<CharacterCtrl>
{
    [Header("Lane")]
    [SerializeField] protected int lane;
    public int Lane => lane;
    [SerializeField] protected bool isGround = false;
    public bool IsGround => isGround;

    [Header("Character Ctrl")]
    [SerializeField] protected CharacterTargeting characterTargeting;
    public CharacterTargeting CharacterTargeting => characterTargeting;

    [SerializeField] protected CharacterAttack characterAttack;
    public CharacterAttack CharacterAttack => characterAttack;

    [SerializeField] protected CharacterDamageReceiver characterDamageReceiver;
    public CharacterDamageReceiver CharacterDamageReceiver => characterDamageReceiver;

    [SerializeField] protected CharacterLevel characterLevel;
    public CharacterLevel CharacterLevel => characterLevel;

    [SerializeField] protected CharacterAttribute characterAttribute;
    public CharacterAttribute CharacterAttribute => characterAttribute;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterTargeting();
        this.LoadCharacterAttack();
        this.LoadCharacterDamageReceiver();
        this.LoadCharacterLevel();
        this.LoadCharacterAttribute();
    }
    protected virtual void OnEnable()
    {
        CharacterManagerCtrl.Instance.CharacterManager.RegisterObject(this);

    }

    protected virtual void LoadCharacterAttack()
    {
        if (this.characterAttack != null) return;
        this.characterAttack = transform.GetComponentInChildren<CharacterAttack>();
        Debug.Log(transform.name + ": Load CharacterAttack ", gameObject);
    }

    protected virtual void LoadCharacterTargeting()
    {
        if (this.characterTargeting != null) return;
        this.characterTargeting = transform.GetComponentInChildren<CharacterTargeting>();
        Debug.Log(transform.name + ": Load CharacterTargeting", gameObject);
    }

    protected virtual void LoadCharacterDamageReceiver()
    {
        if (this.characterDamageReceiver != null) return;
        this.characterDamageReceiver = transform.GetComponentInChildren<CharacterDamageReceiver>();
        Debug.Log(transform.name + ": Load CharacterDamageReceiver ", gameObject);
    }
    protected virtual void LoadCharacterLevel()
    {
        if (this.characterLevel != null) return;
        this.characterLevel = transform.GetComponentInChildren<CharacterLevel>();
        Debug.Log(transform.name + ": Load CharacterLevel ", gameObject);
    }
    protected virtual void LoadCharacterAttribute()
    {
        if (this.characterAttribute != null) return;
        this.characterAttribute = transform.GetComponentInChildren<CharacterAttribute>();
        Debug.Log(transform.name + ": Load CharacterAttribute ", gameObject);
    }


    public virtual void SetLane(int Lane ) => this.lane = Lane;

  
}
