using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterManagerCtrl : Singleton<CharacterManagerCtrl>
{
    [SerializeField] protected CharacterManager characterManager;
    public CharacterManager CharacterManager => characterManager;

    [SerializeField] protected CharacterSpawner characterSpawner;
    public CharacterSpawner CharacterSpawner => characterSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterManager();
        this.LoadCharacterSpawner();
    }

    protected virtual void LoadCharacterManager()
    {
        if (this.characterManager != null) return;
        this.characterManager = transform.GetComponent<CharacterManager>();
        Debug.Log(transform.name + ": Load CharacterManager", gameObject);
    }

    protected virtual void LoadCharacterSpawner()
    {
        if (this.characterSpawner != null) return;
        this.characterSpawner = transform.GetComponentInChildren<CharacterSpawner>(true);
        Debug.Log(transform.name + ": Load CharacterSpawner", gameObject);
    }
}
