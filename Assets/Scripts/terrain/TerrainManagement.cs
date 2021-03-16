using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManagement : TerrainConfig
{
    public Terrain t;

    protected override void UpdateTerrainData(float[,] data)
    {   
        t.terrainData.heightmapResolution = (int)size.x;
        t.terrainData.SetHeights(0, 0, data);
    }
}
