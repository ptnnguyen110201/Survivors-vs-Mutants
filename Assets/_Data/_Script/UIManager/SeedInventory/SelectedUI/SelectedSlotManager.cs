using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedSlotManager : LoadComPonent
{
    [SerializeField] protected SelectedSlot selectedSlot;
    [SerializeField] protected List<SelectedSlot> selectedSlots;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectedSlot();
    }

    protected virtual void LoadSelectedSlot()
    {
        if (this.selectedSlot != null) return;
        this.selectedSlot = transform.GetComponentInChildren<SelectedSlot>(true);
        Debug.Log(transform.name + ": Load SelectedSlot", gameObject);
    }

    protected virtual void LateUpdate()
    {
        this.UpdatingAvailableSlot();
    }
    protected virtual void UpdatingAvailableSlot()
    {
        List<CharacterBuyProfile> characterBuyProfiles = SeedInventory.Instance.SelectedProfile;
        this.selectedSlots.RemoveAll(slot =>
        {
            if (!characterBuyProfiles.Contains(slot.CharacterBuyProfile))
            {
                Destroy(slot.gameObject); 
                return true; 
            }
            return false;
        });

        foreach (CharacterBuyProfile characterBuyProfile in characterBuyProfiles)
        {
            SelectedSlot existingSlot = GetExistItem(characterBuyProfile);
            if (existingSlot == null)
            {
                existingSlot = Instantiate(this.selectedSlot);
                existingSlot.transform.SetParent(this.selectedSlot.transform.parent);
                existingSlot.transform.localScale = Vector3.one;
                selectedSlots.Add(existingSlot);
            }
            bool isStarting = GameManager.Instance.IsStart;
            existingSlot.SetAvaiableSlot(characterBuyProfile, isStarting, this.IsCanBuy(characterBuyProfile));
            existingSlot.gameObject.SetActive(true);
        }
       
    }

    protected virtual SelectedSlot GetExistItem(CharacterBuyProfile characterBuyProfile)
    {
        foreach (SelectedSlot availableSlot in this.selectedSlots)
        {
            if (availableSlot.CharacterBuyProfile == characterBuyProfile) 
            return availableSlot;
        }
        return null;
    }
    protected virtual bool IsCanBuy(CharacterBuyProfile characterBuyProfile) 
    {
        ItemInventory itemGold = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
        if(itemGold == null) return false;  
        if(itemGold.itemCount < characterBuyProfile.chacracterCoints) return false;
        return true;
    }
}
