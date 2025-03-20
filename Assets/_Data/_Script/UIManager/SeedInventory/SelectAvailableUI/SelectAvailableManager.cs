using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAvailableManager : LoadComPonent
{

    [SerializeField] protected SelectAvailableSlot selectedSlot;
    [SerializeField] protected List<SelectAvailableSlot> selectAvailableSlot;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectAvailableSlot();
    }

    protected virtual void LoadSelectAvailableSlot()
    {
        if (this.selectedSlot != null) return;
        this.selectedSlot = transform.GetComponentInChildren<SelectAvailableSlot>(true);
        Debug.Log(transform.name + ": Load SelectAvailableSlot", gameObject);
    }

    protected virtual void LateUpdate()
    {
        this.UpdatingAvailableSlot();
    }
    protected virtual void UpdatingAvailableSlot()
    {
        this.ClearSlot();
        if (GameManager.Instance.IsStart) return;
        List<CharacterBuyProfile> characterBuyProfiles = SeedInventory.Instance.SelectedProfile;
        this.selectAvailableSlot.RemoveAll(slot =>
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
            SelectAvailableSlot existingSlot = GetExistItem(characterBuyProfile);
            if (existingSlot == null)
            {
                existingSlot = Instantiate(this.selectedSlot);
                existingSlot.transform.SetParent(this.selectedSlot.transform.parent);
                existingSlot.transform.localScale = Vector3.one;
                selectAvailableSlot.Add(existingSlot);
            }
            bool isStarting = GameManager.Instance.IsStart;
            existingSlot.SetAvaiableSlot(characterBuyProfile);
            existingSlot.gameObject.SetActive(true);
        }

    }

    protected virtual SelectAvailableSlot GetExistItem(CharacterBuyProfile characterBuyProfile)
    {
        foreach (SelectAvailableSlot availableSlot in this.selectAvailableSlot)
        {
            if (availableSlot.CharacterBuyProfile == characterBuyProfile)
                return availableSlot;
        }
        return null;
    }


    protected virtual void ClearSlot()
    {
        for (int i = selectAvailableSlot.Count - 1; i >= 0; i--)  
        {
            Destroy(selectAvailableSlot[i].gameObject);
            selectAvailableSlot.RemoveAt(i);
        }
    }
}
