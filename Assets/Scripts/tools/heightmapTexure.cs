using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightmapTexure : TerrainConfig
{
    private Material mat;

    // Start is called before the first frame update
    protected override void UpdateTerrainData(float[,] data)
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;

        mat.mainTexture = GeneratorTool.TextureGeneration(data);
        mat.mainTexture.filterMode = FilterMode.Point;
        mat.mainTexture.wrapMode = TextureWrapMode.Clamp;
    }
}
