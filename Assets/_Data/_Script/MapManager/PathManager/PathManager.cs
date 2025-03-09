using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : LoadComPonent
{
    [SerializeField] protected List<PathMap> pathMaps = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPathMaps();
    }


    protected virtual void LoadPathMaps() 
    {
        if (this.pathMaps.Count > 0) return;
        foreach(Transform obj in this.transform) 
        {
            if(obj == null) continue;
            PathMap pathMap = obj.GetComponent<PathMap>();
            if (pathMap == null) continue;
            pathMap.LoadPoints();
            this.pathMaps.Add(pathMap);
       
        }

        Debug.Log(transform.name + ": Load PathMaps:" + this.pathMaps.Count, gameObject);

    }

    public PathMap GetRandomPathMap() 
    {
        int index = Random.Range(0, this.pathMaps.Count);
        return this.pathMaps[index];
    }

}
