using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManagement : TerrainConfig
{
    public Terrain t;

    [Header("Terrain Texture Settings")]
    public List<GeneratorTool.LayerData> layers;

    protected override void UpdateTerrainData(float[,] data)
    {
        t.terrainData.heightmapResolution = (int)size.x;
        t.terrainData.SetHeights(0, 0, data);
    }
    protected void UpdateTerrainTexture(float[,] data)
    {
        t.terrainData.alphamapResolution = (int)size.x;
        t.terrainData.SetAlphamaps(0, 0, GeneratorTool.GenerateTextureData(data, layers.ToArray()));
    }
}
