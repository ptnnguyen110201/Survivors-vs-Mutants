using Unity.VisualScripting;
using UnityEngine;

public class ProfileManager : Singleton<ProfileManager>
{
    [SerializeField] protected CharacterCtrl selectedCharacterCtrl;
    public CharacterCtrl SelectedCharacterCtrl => selectedCharacterCtrl;
    [SerializeField] protected ProfileInfo profileInfo;
    protected bool isShow = true;
    protected bool IsShow => isShow;


    protected virtual void Start()
    {
        this.Hide();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if (this.profileInfo != null) return;
        this.profileInfo = transform.GetComponentInChildren<ProfileInfo>(true);
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.profileInfo.gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        this.isShow = false;
        this.profileInfo.gameObject.SetActive(this.isShow);
        
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }
    public virtual void SetCharacterCtrl(CharacterCtrl selectedCharacterCtrl) => this.selectedCharacterCtrl = selectedCharacterCtrl;

}
