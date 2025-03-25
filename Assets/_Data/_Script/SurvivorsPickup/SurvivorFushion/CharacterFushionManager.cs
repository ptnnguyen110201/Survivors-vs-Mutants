using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterFushionManager : Singleton<CharacterFushionManager>
{
    public virtual bool Fushion(CharacterCtrl selectedCharacter, CharacterCtrl hitCharacter)
    {
        Vector3 mouseWorldPosition = InputManager.Instance.mouseWolrdPos;

        if (selectedCharacter == null) return false;
        CharacterProfile selectedProfile = selectedCharacter.ObjectProfile as CharacterProfile;
        if (selectedProfile == null) return false;

        if (hitCharacter == null) return false;
        CharacterProfile hitCharacterProfile = hitCharacter.ObjectProfile as CharacterProfile;
        if (hitCharacterProfile == null) return false;

   
   

        CharacterMergeProfile characterMergeProfile = hitCharacterProfile.GetCharacterMergeProfile(selectedProfile);
        if (characterMergeProfile == null) return false;

        selectedCharacter.DespawnBase.DespawnObj(); 
        hitCharacter.DespawnBase.DespawnObj();
       
        CharacterCtrl newCharacter = CharacterManagerCtrl.Instance.CharacterSpawner.SpawnCharacter(characterMergeProfile.mergedProfile, hitCharacter.transform.position);
        newCharacter.SetLane(hitCharacter.Lane);
        newCharacter.gameObject.SetActive(true);

        return true;
    }
    public virtual void ShowCanFushion(CharacterProfile selected)
    {
        List<CharacterCtrl> characterCtrls = CharacterManagerCtrl.Instance.CharacterManager.T_ListObj;
        foreach (CharacterCtrl characterCtrl in characterCtrls) 
        {
            if(characterCtrl == null) continue;
            CharacterProfile characterProfile = characterCtrl.ObjectProfile as CharacterProfile;
            if (characterProfile == null) continue;
            CharacterMergeProfile characterMergeProfile = characterProfile.GetCharacterMergeProfile(selected);
            if (characterMergeProfile == null) continue;
            characterCtrl.CharacterHUD.ShowFushionIMG(true);
        }
    }
    public virtual void HideAllFusionIcons()
    {
        List<CharacterCtrl> characterCtrls = CharacterManagerCtrl.Instance.CharacterManager.T_ListObj;
        foreach (CharacterCtrl characterCtrl in characterCtrls)
        {
            if (characterCtrl == null) continue;
            characterCtrl.CharacterHUD.ShowFushionIMG(false);
        }
    }
}
