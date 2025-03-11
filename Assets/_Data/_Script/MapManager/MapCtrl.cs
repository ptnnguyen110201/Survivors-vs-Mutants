using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : LoadComPonent
{
    [SerializeField] protected PlacementMap placementMap;
    public PlacementMap PlacementMap => placementMap;
    [SerializeField] protected PathManager pathManager;
    public PathManager PathManager => pathManager;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathManager();
        this.LoadPlacementMap();
    }
    protected virtual void LoadPlacementMap()
    {
        if (this.placementMap != null) return;
        this.placementMap = transform.GetComponentInChildren<PlacementMap>();
        Debug.Log(transform.name + ": Load PlacementMap ", gameObject);
    }

    protected virtual void LoadPathManager()
    {
        if (this.pathManager != null) return;
        this.pathManager = transform.GetComponentInChildren<PathManager>();
        Debug.Log(transform.name + ": Load PathManager", gameObject);
    }
}
