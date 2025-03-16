using UnityEngine;

public class GameManagerUI : Singleton<GameManagerUI>
{
    [SerializeField] protected AvailableSlotManager availableSlotManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAvailableSlotManager();
    }


    protected virtual void LoadAvailableSlotManager() 
    {
        if (this.availableSlotManager != null) return;
        this.availableSlotManager = transform.GetComponentInChildren<AvailableSlotManager>(true);
        Debug.Log(transform.name + ": Load AvailableSlotManager ", gameObject);
    }


    public virtual void StartGameUI() 
    {
        this.availableSlotManager.gameObject.SetActive(false);
    }
}
