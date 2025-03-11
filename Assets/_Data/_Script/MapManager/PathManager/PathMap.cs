using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathMap : LoadComPonent
{
    [SerializeField] protected int mapLane;
    [SerializeField] protected Tilemap tileMap;
    [SerializeField] protected List<Vector3> Points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTileMap();

    }

    protected virtual void LoadTileMap()
    {
        if (this.tileMap != null) return;
        this.tileMap = transform.GetComponent<Tilemap>();
        Debug.Log(transform.name + ": Load TileMap", gameObject);
    }

    public virtual void LoadPoints()
    {
       
        if (this.tileMap == null) return;
        this.Points.Clear();

        BoundsInt bounds = this.tileMap.cellBounds;
        Vector3 tileSize = this.tileMap.layoutGrid.cellSize;
        Vector3 offset = new Vector3(tileSize.x / 2, tileSize.y / 4, 0);

        for (int x = bounds.xMax - 1; x >= bounds.xMin; x--)
        {
            for (int y = bounds.yMax - 1; y >= bounds.yMin; y--)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                if (!this.tileMap.HasTile(cellPos)) continue;

                Vector3 worldPos = this.tileMap.CellToWorld(cellPos) + offset;
                this.Points.Add(worldPos);
            }
        }
        Debug.Log(transform.name + ": Load Point", gameObject);
    }

    public virtual List<Vector3> GetPoints() => this.Points;
    public virtual Vector3 GetSpawnPoint() => this.Points[0];

    public virtual int GetMapLane() => this.mapLane;
    public virtual void SetMapLane(int laneMap) => this.mapLane = laneMap;
}
