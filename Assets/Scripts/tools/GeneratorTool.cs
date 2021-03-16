using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTool
{
    public static Texture2D TextureGeneration(float[,] data)
    {
        int witdh = data.GetLength(0);
        int height = data.GetLength(1);

        Texture2D texture = new Texture2D(witdh, height);

        Color[] colors = new Color[witdh * height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < witdh; x++)
            {
                int i = x + witdh * y;
                float value = data[x, y];
                colors[i] = new Color(value, value, value);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        return texture;
    }

    public static float[,] FilterMap(float[,] data, float innerRadius, float outerRadius)
    {
        Vector2Int center = new Vector2Int(data.GetLength(0) / 2, data.GetLength(1) / 2);

        for (int y = 0; y < data.GetLength(0); y++)
        {
            for (int x = 0; x < data.GetLength(1); x++)
            {
                Vector2Int point = new Vector2Int(x, y);
                float distance = Vector2.Distance(center, point);
                float multiplier;

                if (distance < innerRadius)
                {
                    multiplier = 1.0f;
                }
                else if (distance > outerRadius)
                {
                    multiplier = 0.0f;
                }
                else
                {
                    multiplier = GeneratorTool.Map(distance, innerRadius, outerRadius, 1f, 0f);
                }

                data[x, y] *= multiplier;
            }
        }

        return data;
    }

    public static float[,] GenerateTerrainData(int witdh, int height, float scale, float baseAmplitude, int octaves, float lacunarity, float presistense, Vector3 offset)
    {
        float[,] result = new float[witdh, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < witdh; x++)
            {
                result[x, y] = 0;
                float frequency = scale;
                float amplitude = 1;

                for (int i = 0; i < octaves; i++)
                {
                    frequency *= lacunarity;
                    amplitude *= presistense;
                    result[x, y] += GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude + offset.z / 100.0f);

                    if (result[x, y] > maxValue)
                    {
                        maxValue = result[x, y];
                    }
                    else if (result[x, y] < minValue)
                    {
                        minValue = result[x, y];
                    }
                }
            }
        }

        return result;
    }

    public static float Map(float value, float valueMin, float valueMax, float resultMin, float resultMax)
    {
        if (resultMin == resultMax) return resultMin;
        if (valueMin == valueMax) return resultMax;
        return resultMin + (value - valueMin) * (resultMax - resultMin) / (valueMax - valueMin);
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = (Mathf.PerlinNoise(x * frequency, y * frequency) * 2f - 1) * amplitude;

        return result;
    }
}
