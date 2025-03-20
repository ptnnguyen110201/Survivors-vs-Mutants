using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileInfo : LoadComPonent
{

    [SerializeField] protected Image Profile_IMG;
    [SerializeField] protected TextMeshProUGUI Profile_Name;
    [SerializeField] protected TextMeshProUGUI Profile_Hp;
    [SerializeField] protected TextMeshProUGUI Profile_ATK;
    [SerializeField] protected TextMeshProUGUI Profile_AFR;
    [SerializeField] protected List<Transform> Profile_Star;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadProfile();
    }

    protected virtual void LoadProfile()
    {
        this.Profile_IMG = transform.Find("Profile_IMG/IMG").GetComponent<Image>();
        this.Profile_Name = transform.Find("Profile_Name/Text").GetComponent<TextMeshProUGUI>();
        this.Profile_Hp = transform.Find("Profile_Attribute/HP/Count").GetComponent<TextMeshProUGUI>();
        this.Profile_ATK = transform.Find("Profile_Attribute/ATK/Count").GetComponent<TextMeshProUGUI>();
        this.Profile_AFR = transform.Find("Profile_Attribute/AFR/Count").GetComponent<TextMeshProUGUI>();
        foreach (Transform obj in transform.Find("Profile_Attribute/Star"))
        {
            if (obj == null) continue;
            this.Profile_Star.Add(obj);
        }
    }
    protected void LateUpdate()
    {
        this.SetInfo();
    }
    public virtual void SetInfo() 
    {
        CharacterCtrl characterCtrl = ProfileManager.Instance.SelectedCharacterCtrl;
        if (characterCtrl == null) return;

        CharacterProfile characterProfile = characterCtrl.ObjectProfile as CharacterProfile;
        this.Profile_IMG.sprite = characterProfile.characterSprite;
        this.Profile_Name.text = $"{characterCtrl.name}";
        this.Profile_Hp.text = $"{characterCtrl.CharacterDamageReceiver.CurrentHp}/{characterCtrl.CharacterAttribute.Attributes.maxHP}";
        this.Profile_ATK.text = $"{characterCtrl.CharacterAttribute.Attributes.attackDamage}";
        this.Profile_AFR.text = $"{characterCtrl.CharacterAttribute.Attributes.fireRate}";
        this.SetLevel(characterCtrl);
    }

    protected void SetLevel(CharacterCtrl characterCtrl) 
    {

        int level = characterCtrl.CharacterLevel.GetCurrentLevel();
        foreach (Transform obj in this.Profile_Star) 
        {
            obj.gameObject.SetActive(false);
        }
        for (int i = 0; i < level; i++) 
        {
            this.Profile_Star[i].gameObject.SetActive(true);
        }
    }
   
}
