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

    public static float[,] GenerateTerrainData(int witdh, int height, float scale, int octaves, float lacunarity, float presistense, Vector2 offset)
    {
        float[,] result = new float[witdh, height];

        float maxValue = float.MinValue;
        float minValue = float.MaxValue;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < witdh; x++)
            {
                result[x, y] = 0;
                float frequency = 0.005f;
                float amplitude = 1;

                for (int i = 0; i < octaves; i++)
                {
                    frequency *= lacunarity;
                    amplitude *= presistense;
                    result[x, y] += GetPerlinValue(x + offset.x, y + offset.y, frequency, amplitude);

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

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < witdh; x++)
            {
                result[x, y] = Mathf.InverseLerp(minValue, maxValue, result[x, y]);
            }
        }

        return result;
    }

    public static float GetPerlinValue(float x, float y, float frequency, float amplitude)
    {
        float result = Mathf.PerlinNoise(x * frequency, y * frequency) * amplitude;

        return result;
    }
}
