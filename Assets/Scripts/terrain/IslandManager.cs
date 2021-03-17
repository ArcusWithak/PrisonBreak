using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandManager : TerrainManagement
{
    [Header("Island Settings")]
    [Tooltip("Area of the center of the island that will remain untouched by the filter")]
    public float innerRadius;
    [Tooltip("Area at the edges of the island that will be completely flat.")]
    public float outerRadius;

    public bool RegenerateRaftParts = false;

    public GameObject[] raftParts;
    protected override void UpdateTerrainData(float[,] data)
    {
        data = GeneratorTool.FilterMap(data, innerRadius, outerRadius);
        base.UpdateTerrainData(data);
        if (RegenerateRaftParts) { GenerateRaftItems(data); }
    }

    protected void GenerateRaftItems(float[,] data)
    {
        RegenerateRaftParts = false;
        Vector2 center = new Vector2(size.x, size.y);
        foreach (GameObject part in raftParts)
        {
            Vector3 spawnPoint = Random.insideUnitCircle * (outerRadius / 2) + center;
            spawnPoint = new Vector3(spawnPoint.x, 150, spawnPoint.y);
            Instantiate(part, spawnPoint, Quaternion.identity);
        }
    }
}
