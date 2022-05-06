using UnityEngine;

public class WMeshHelper
{

    public static int[] WOrderOfVerticesToTriangles(WOrderOfVertices[] wOrderOfVertices)
    {
        int trianglesLenght = wOrderOfVertices.Length * 3;
        int[] triangles = new int[trianglesLenght];
        int trianglesID = 0;
        for (int i = 0; i < wOrderOfVertices.Length; i++)
        {
            WOrderOfVertices WOrderOfVertices = wOrderOfVertices[i];
            triangles[trianglesID + 0] = WOrderOfVertices.A;
            triangles[trianglesID + 1] = WOrderOfVertices.B;
            triangles[trianglesID + 2] = WOrderOfVertices.C;

            trianglesID += 3;
        }

        return triangles;
    }

    public static float WGenerateNoise(int x, int z, float scale, Vector3 pos, float offset)
    {
        float wX = (x + pos.x) / scale + offset;
        float wZ = (z + pos.z) / scale + offset;
        return Mathf.PerlinNoise(wX, wZ);
    }
}
