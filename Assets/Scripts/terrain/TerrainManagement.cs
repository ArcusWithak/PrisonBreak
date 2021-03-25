using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManagement : TerrainConfig
{
    public Terrain t;

    [Header("Terrain Texture Settings")]
    public List<GeneratorTool.LayerData> layers;

    [Header("Tree Generation Settings")]
    public bool generateTrees = true;

    public float treeScale;
    public List<GeneratorTool.TreeLayerData> treeLayers;

    protected override void UpdateTerrainData(float[,] data)
    {
        t.terrainData.heightmapResolution = (int)size.x;
        t.terrainData.SetHeights(0, 0, data);
        UpdateTerrainTexture(data);
        CreateTrees();
    }
    protected void UpdateTerrainTexture(float[,] data)
    {
        t.terrainData.alphamapResolution = (int)size.x;
        t.terrainData.SetAlphamaps(0, 0, GeneratorTool.GenerateTextureData(data, layers.ToArray()));
    }

    protected void CreateTrees()
    {
        if (generateTrees)
        {
            float[,] data = t.terrainData.GetHeights(0, 0, (int)size.x, (int)size.y);
            List<TreeInstance> trees = new List<TreeInstance>();

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    float heightValue = data[x, y];
                    for (int l = 0; l < treeLayers.Count; l++)
                    {
                        if (treeLayers[l].Generate(heightValue))
                        {
                            TreeInstance treeInstance = new TreeInstance();
                            treeInstance.prototypeIndex = treeLayers[l].index;
                            treeInstance.heightScale = treeScale;
                            treeInstance.widthScale = treeScale;
                            treeInstance.rotation = Random.Range(0, Mathf.PI * 2);
                            treeInstance.position = new Vector3(y / size.y, 0, x / size.x);
                            trees.Add(treeInstance);
                        }
                    }
                }
            }

            t.terrainData.SetTreeInstances(trees.ToArray(), true);
            //t.Flush();
        }
    }
}
