using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPaint : MonoBehaviour
{
    public float scale = 50;
    public int xOffset = 1;
    public int yOffset = 1;
    public float coef = 1;
    private float[,,] alphaData;
    private TerrainData tData;

    public void Paint() {
        tData = Terrain.activeTerrain.terrainData;
        alphaData = tData.GetAlphamaps(0, 0, tData.alphamapWidth, tData.alphamapHeight);

        for (int y = 0; y < tData.alphamapHeight; y++){
            for (int x = 0; x < tData.alphamapWidth; x++){
                float kx = (((float)x * xOffset) / tData.alphamapWidth) * scale;
                float ky = (((float)y * yOffset) / tData.alphamapHeight) * scale;
                float ty = Mathf.PerlinNoise(kx, ky) * coef;

                //float tr = Mathf.PerlinNoise(kx * 8, ky * 8) * coef;
                //tr = tr > 0.5f ? 0.5f : tr;
                //ty = ty < tr ? tr : ty;

                alphaData[x, y, 0] = 1 - ty;
                alphaData[x, y, 1] = ty;
            }
        }
       
        tData.SetAlphamaps(0, 0, alphaData);
    }
}

