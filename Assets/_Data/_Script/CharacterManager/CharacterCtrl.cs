
using UnityEngine;

public class CharacterCtrl : ObjectCtrl<CharacterCtrl>
{
    [Header("Lane")]
    [SerializeField] protected int lane;
    public int Lane => lane;

    [SerializeField] protected bool isSelecting = false;
    public bool IsSelecting => isSelecting;

    public virtual void SetIsFushioning(bool isSelecting = false) => this.isSelecting = isSelecting;
    public virtual void SetPos(Vector3 Pos) => this.transform.position = Pos;
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

    [SerializeField] protected CharacterHUD characterHUD;
    public CharacterHUD CharacterHUD => characterHUD;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterTargeting();
        this.LoadCharacterAttack();
        this.LoadCharacterDamageReceiver();
        this.LoadCharacterLevel();
        this.LoadCharacterAttribute();
        this.LoadCharacterHUD();
    }

    protected void OnEnable()
    {
        CharacterManagerCtrl.Instance.CharacterManager.RegisterObject(this);
    }
    protected virtual void LoadCharacterAttack()
    {
        if (this.characterAttack != null) return;
        this.characterAttack = transform.GetComponentInChildren<CharacterAttack>(true);
        Debug.Log(transform.name + ": Load CharacterAttack ", gameObject);
    }

    protected virtual void LoadCharacterTargeting()
    {
        if (this.characterTargeting != null) return;
        this.characterTargeting = transform.GetComponentInChildren<CharacterTargeting>(true);
        Debug.Log(transform.name + ": Load CharacterTargeting", gameObject);
    }

    protected virtual void LoadCharacterDamageReceiver()
    {
        if (this.characterDamageReceiver != null) return;
        this.characterDamageReceiver = transform.GetComponentInChildren<CharacterDamageReceiver>(true);
        Debug.Log(transform.name + ": Load CharacterDamageReceiver ", gameObject);
    }
    protected virtual void LoadCharacterLevel()
    {
        if (this.characterLevel != null) return;
        this.characterLevel = transform.GetComponentInChildren<CharacterLevel>(true);
        Debug.Log(transform.name + ": Load CharacterLevel ", gameObject);
    }
    protected virtual void LoadCharacterAttribute()
    {
        if (this.characterAttribute != null) return;
        this.characterAttribute = transform.GetComponentInChildren<CharacterAttribute>(true);
        Debug.Log(transform.name + ": Load CharacterAttribute ", gameObject);
    }
    protected virtual void LoadCharacterHUD()
    {
        if (this.characterHUD != null) return;
        this.characterHUD = transform.GetComponentInChildren<CharacterHUD>(true);
        Debug.Log(transform.name + ": Load CharacterHUD ", gameObject);
    }

    public virtual void SetLane(int Lane ) => this.lane = Lane;

  
}
