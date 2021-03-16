using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainConfig : MonoBehaviour
{
    public Vector2 size;
    public float scale = 1f;
    [Range(0, 1)]
    public float baseAmplitude = 1f;
    [Range(1, 10)]
    public int octaves = 4;
    [Range(1, 3)]
    public float lacunarity = 1.5f;
    [Range(0.001f, 1)]
    public float presistense = 0.5f;
    public Vector3 offSet = Vector2.zero;

    private void Start()
    {
        UpdateTerrainData(generateTerrainData());
    }

    protected float[,] generateTerrainData()
    {
        return GeneratorTool.GenerateTerrainData((int)size.x, (int)size.y, scale / 100, baseAmplitude, octaves, lacunarity, presistense, offSet);
    }

    protected virtual void UpdateTerrainData(float[,] data)
    {

    }

    private void OnValidate()
    {
        UpdateTerrainData(generateTerrainData());
    }
}
