using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopUI : Singleton<StopUI>
{
    protected bool isShow = true;
    protected bool IsShow => isShow;

    [SerializeField] protected Transform showHide;

    protected virtual void Start()
    {
        this.Hide();
    }
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleInventory();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShowHide();
    }

    protected virtual void LoadShowHide()
    {
        if (this.showHide != null) return;
        this.showHide = transform.Find("ShowHide");
        Debug.Log(transform.name + ": LoadShowHide", gameObject);
    }

    public virtual void Show()
    {
        this.isShow = true;
        this.showHide.gameObject.SetActive(this.isShow);
        GameManager.Instance.SetStop(this.isShow);
    }

    public virtual void Hide()
    {
        this.showHide.gameObject.SetActive(false);
        this.isShow = false;
        GameManager.Instance.SetStop();
    }

    public virtual void Toggle()
    {
        if (this.isShow) this.Hide();
        else this.Show();
    }
    protected virtual void HotkeyToogleInventory()
    {
        if (InputKeyManager.Instance.isSpace) this.Toggle();
    }
}