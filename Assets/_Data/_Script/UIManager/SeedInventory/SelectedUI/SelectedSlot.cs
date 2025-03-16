using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSlot : ButtonAbstract
{
    [SerializeField] protected CharacterBuyProfile characterBuyProfile;
    public CharacterBuyProfile CharacterBuyProfile => characterBuyProfile;
    [SerializeField] protected Image characterImage;
    [SerializeField] protected TextMeshProUGUI characterCoints;

    [SerializeField] protected bool isStarting = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterImage();
        this.LoadCharacterCoints();
    }

    public virtual void SetAvaiableSlot(CharacterBuyProfile characterBuyProfile, bool isStarting, bool isCanBuy = true)
    {
        this.characterBuyProfile = characterBuyProfile;
        this.characterImage.sprite = characterBuyProfile.chacracterSprite;
        this.isStarting = isStarting;
        this.characterCoints.text = characterBuyProfile.chacracterCoints.ToString();
        if (!this.isStarting) return;
        this.button.interactable = isCanBuy;
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
        if (this.isStarting) CharacterPutManager.Instance.SetSelectedSlot(this);
        else SeedInventory.Instance.DeselectSeed(this.characterBuyProfile); 
    }
}
