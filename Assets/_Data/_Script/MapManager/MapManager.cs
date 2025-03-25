using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] protected List<MapCtrl> listMaps;
    [SerializeField] protected MapCtrl currentMap;
    public MapCtrl CurrentMap => currentMap;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMaps();
      
    }
    protected virtual void LoadMaps() 
    {

        if (this.listMaps.Count > 0) return;
        foreach (Transform obj in this.transform.Find("Prefabs"))
        {
            if (obj == null) continue;
            MapCtrl mapCtrl = obj.GetComponent<MapCtrl>();
            if (mapCtrl == null) continue;
            this.listMaps.Add(mapCtrl);

        }

        Debug.Log(transform.name + ": Load PathMaps:" + this.listMaps.Count, gameObject);
    }
}
