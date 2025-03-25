
using UnityEngine.EventSystems;

public class CharacterPickup : ObjectPickup<CharacterCtrl>, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (CharacterPutManager.Instance.IsTranslating) this.OnTranslateCharacter(); 
        else this.OnPointerDown();
        
        
    }

    protected override void OnPointerDown()
    {
        ProfileManager.Instance.SetCharacterCtrl(this.ObjParent);
        ProfileManager.Instance.Show();
    }
    
    protected virtual void OnTranslateCharacter() 
    {
      
        CharacterPutManager.Instance.SetSelectSurvivorCtrl(this.ObjParent);
    }
}
