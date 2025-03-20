using System.Collections;
using TMPro;
using UnityEngine;


public class TimeScaleBtn : ButtonAbstract
{
    [SerializeField] protected TextMeshProUGUI timeScaleText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTimeScaleText();
    }

    protected void LateUpdate()
    {
        this.ShowTimeScale();
    }
    protected virtual void ShowTimeScale() 
    {
        float TimeScale = GameManager.Instance.CurrentTimeScale;
        this.timeScaleText.text = $"x{TimeScale}";
    }
    protected virtual void LoadTimeScaleText() 
    {
        if (this.timeScaleText != null) return;
        this.timeScaleText = transform.GetComponentInChildren<TextMeshProUGUI>(true);
        Debug.Log(transform.name + "Load TimeScaleText ", gameObject);
    }
    protected override void OnClick()
    {
        GameManager.Instance.IncreaseTimeScale();
    }
}
