using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSurvivorManager : Singleton<SelectSurvivorManager>
{

    [SerializeField] protected SelectSurvivorSlot selectSurvivorSlot;
    [SerializeField] protected List<SelectSurvivorSlot> selectSurvivorSlots;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectSurvivorSlot();
    }

    protected virtual void LoadSelectSurvivorSlot()
    {
        if (this.selectSurvivorSlot != null) return;
        this.selectSurvivorSlot = transform.GetComponentInChildren<SelectSurvivorSlot>(true);
        Debug.Log(transform.name + ": Load SelectSurvivorSlot", gameObject);
    }

    protected virtual void LateUpdate()
    {
        this.UpdatingAvailableSlot();
    }
    protected virtual void UpdatingAvailableSlot()
    {
        if (!GameManager.Instance.IsStart) return;
        List<CharacterBuyProfile> characterBuyProfiles = SeedInventory.Instance.SelectedProfile;
        this.selectSurvivorSlots.RemoveAll(slot =>
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
            SelectSurvivorSlot existingSlot = GetExistItem(characterBuyProfile);
            if (existingSlot == null)
            {
                existingSlot = Instantiate(this.selectSurvivorSlot);
                existingSlot.transform.SetParent(this.selectSurvivorSlot.transform.parent);
                existingSlot.transform.localScale = Vector3.one;
                selectSurvivorSlots.Add(existingSlot);
            }

            existingSlot.SetSelectSurvivorSlot(characterBuyProfile, this.IsCanBuy(characterBuyProfile));
            existingSlot.gameObject.SetActive(true);
        }

    }

    protected virtual SelectSurvivorSlot GetExistItem(CharacterBuyProfile characterBuyProfile)
    {
        foreach (SelectSurvivorSlot availableSlot in this.selectSurvivorSlots)
        {
            if (availableSlot.CharacterBuyProfile == characterBuyProfile)
                return availableSlot;
        }
        return null;
    }
    protected virtual bool IsCanBuy(CharacterBuyProfile characterBuyProfile)
    {
        ItemInventory itemGold = InventoryManager.Instance.Currencies().FindItem(ItemEnum.Gold);
        if (itemGold == null) return false;
        if (itemGold.itemCount < characterBuyProfile.chacracterCoints) return false;
        return true;
    }


}
