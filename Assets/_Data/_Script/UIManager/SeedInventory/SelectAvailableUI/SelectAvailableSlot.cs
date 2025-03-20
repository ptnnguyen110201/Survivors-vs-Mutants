using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectAvailableSlot : ButtonAbstract
{
    [SerializeField] protected CharacterBuyProfile characterBuyProfile;
    public CharacterBuyProfile CharacterBuyProfile => characterBuyProfile;
    [SerializeField] protected Image characterImage;
    [SerializeField] protected TextMeshProUGUI characterCoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterImage();
        this.LoadCharacterCoints();
    }

    public virtual void SetAvaiableSlot(CharacterBuyProfile characterBuyProfile)
    {
        this.characterBuyProfile = characterBuyProfile;
        this.characterImage.sprite = characterBuyProfile.chacracterSprite;
        this.characterCoints.text = characterBuyProfile.chacracterCoints.ToString();
    }
    protected virtual void LoadCharacterImage()
    {
        if (this.characterImage != null) return;
        this.characterImage = transform.Find("SlotImage").GetComponentInChildren<Image>(true);
        Debug.Log(transform.name + "Load SlotImage ", gameObject);

    }

    protected virtual void LoadCharacterCoints()
    {
        if (this.characterCoints != null) return;
        this.characterCoints = transform.Find("SlotCoints").GetComponentInChildren<TextMeshProUGUI>(true);
        Debug.Log(transform.name + "Load CharacterCoints ", gameObject);

    }

    protected override void OnClick()
    {
        SeedInventory.Instance.DeselectSeed(this.characterBuyProfile);
    }
}
