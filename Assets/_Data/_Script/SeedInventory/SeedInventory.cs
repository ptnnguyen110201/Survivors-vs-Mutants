using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


public class SeedInventory : Singleton<SeedInventory>
{
    [SerializeField] protected List<CharacterBuyProfile> availableProfile;
    public List<CharacterBuyProfile> AvailableProfile => availableProfile;

    [SerializeField] protected List<CharacterBuyProfile> selectedProfile;
    public List<CharacterBuyProfile> SelectedProfile => selectedProfile;

    [SerializeField] protected int maxSelectedSeeds = 8;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvailableProfile();
    }
    protected virtual void LoadAvailableProfile() 
    {
        if (this.availableProfile.Count > 0) return;
        CharacterBuyProfile[] characterBuyProfiles = Resources.LoadAll<CharacterBuyProfile>("/");
        this.availableProfile = new List<CharacterBuyProfile>(characterBuyProfiles);
        Debug.Log(transform.name + ": Load AvailableProfile", gameObject);
    }
    public bool SelectSeed(CharacterBuyProfile seed)
    {
        if (!this.availableProfile.Contains(seed) || this.selectedProfile.Contains(seed))      return false;
        if (this.selectedProfile.Count >= this.maxSelectedSeeds)  return false;
        this.selectedProfile.Add(seed);
        return true;
    }

    public bool DeselectSeed(CharacterBuyProfile seed)
    {
        if (!this.selectedProfile.Contains(seed)) return false;
        this.selectedProfile.Remove(seed);
        return true;
    }

    public virtual bool IsSelectedSlot(CharacterBuyProfile seed) 
    {
        if(!this.selectedProfile.Contains(seed)) return false;
        return true;
    }

}
