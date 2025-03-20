using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterPickup : ObjectPickup<CharacterCtrl>, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        
        this.OnPointerDown();
    }

    protected override void OnPointerDown()
    {
        ProfileManager.Instance.SetCharacterCtrl(this.ObjParent);
        ProfileManager.Instance.Show();
    }
}
