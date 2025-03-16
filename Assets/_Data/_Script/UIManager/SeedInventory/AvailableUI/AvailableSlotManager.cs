using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableSlotManager : LoadComPonent
{
    [SerializeField] protected AvailableSlot availableSlot;
    [SerializeField] protected List<AvailableSlot> availableSlots;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvailableSlot();
    }

    protected virtual void LoadAvailableSlot()
    {
        if (this.availableSlot != null) return;
        this.availableSlot = transform.GetComponentInChildren<AvailableSlot>(true);
        Debug.Log(transform.name + ": Load AvailableSlot", gameObject);
    }

    protected virtual void LateUpdate()
    {
        this.UpdatingAvailableSlot();
    }
    protected virtual void UpdatingAvailableSlot()
    {
        List<CharacterBuyProfile> characterBuyProfiles = SeedInventory.Instance.AvailableProfile;
        if (characterBuyProfiles.Count <= 0) return;
        foreach (CharacterBuyProfile characterBuyProfile in characterBuyProfiles)
        {
            AvailableSlot newSlot = this.GetExistItem(characterBuyProfile);
            if (newSlot == null)
            {
                newSlot = Instantiate(this.availableSlot);
                newSlot.transform.SetParent(this.availableSlot.transform.parent);
                newSlot.transform.localScale = Vector3.one;   
                newSlot.SetAvaiableSlot(characterBuyProfile);
                newSlot.gameObject.SetActive(true);
                this.availableSlots.Add(newSlot);
            }
            
            else newSlot.SetAvaiableSlot(characterBuyProfile);

        }
    }

    protected virtual AvailableSlot GetExistItem(CharacterBuyProfile characterBuyProfile)
    {
        foreach (AvailableSlot availableSlot in this.availableSlots)
        {
            if (availableSlot.CharacterBuyProfile == characterBuyProfile) return availableSlot;
        }
        return null;
    }

}
