using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : ObjectHUD<CharacterCtrl>
{
    [SerializeField] protected Transform FushionIMG;


    public override void ShowFushionIMG(bool canFushion)
    {
        this.FushionIMG.gameObject.SetActive(canFushion);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFushionIMG();
    }
    protected virtual void LoadFushionIMG()
    {
        if (this.FushionIMG != null) return;
        this.FushionIMG = transform.Find("FushionIMG").GetComponent<Transform>();
        Debug.Log(transform.name + ": Load FushionIMG", gameObject);
    }
}
