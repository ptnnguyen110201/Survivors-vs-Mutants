using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectSurvivorSlot : ButtonAbstract, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] protected CharacterBuyProfile characterBuyProfile;
    public CharacterBuyProfile CharacterBuyProfile => characterBuyProfile;
    [SerializeField] protected Image characterImage;
    [SerializeField] protected TextMeshProUGUI characterCoints;
    [SerializeField] protected Vector3 savePosition;
    [SerializeField] protected Vector3 saveLocolcalScale;
    public virtual void SetSelectSurvivorSlot(CharacterBuyProfile characterBuyProfile, bool isCanBuy = true)
    {
        this.characterBuyProfile = characterBuyProfile;
        this.characterImage.sprite = characterBuyProfile.chacracterSprite;
 
        this.characterCoints.text = characterBuyProfile.chacracterCoints.ToString();
       


        if (!isCanBuy) 
        {
            this.characterCoints.color = Color.red; 
            this.button.interactable = isCanBuy;
            return;
        }
        this.characterCoints.color = Color.white;
        this.button.interactable = isCanBuy;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterImage();
        this.LoadCharacterCoints();
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

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!this.button.interactable) return;
        this.savePosition = this.characterImage.transform.position;
        this.saveLocolcalScale = this.characterImage.transform.localScale;
        this.characterImage.raycastTarget = false;
        this.characterImage.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        CharacterPutManager.Instance.SetSelectSurvivorSlot(this.characterBuyProfile);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!this.button.interactable) return;
        Transform obj_Image = this.characterImage.transform;
        obj_Image.position = InputManager.Instance.mouseWolrdPos;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!this.button.interactable) return;
        this.characterImage.raycastTarget = true;
        Transform obj_Image = this.characterImage.transform;
        obj_Image.position = this.savePosition;
        obj_Image.localScale = this.saveLocolcalScale; 
        CharacterPutManager.Instance.SpawnCharacter();
        CharacterPutManager.Instance.SetSelectSurvivorSlot();

    }

    protected override void OnClick()
    {
        return;
    }
}
