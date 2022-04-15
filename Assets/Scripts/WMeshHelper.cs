using UnityEngine;

public class WMeshHelper
{
    public static Vector3[] WVerticesToVertices(WVertices[] wVertices)
    {
        int verticesLenght = wVertices.Length * 3;
        Vector3[] vertices = new Vector3[verticesLenght];
        int verticesID = 0;
        for (int i = 0; i < wVertices.Length; i++)
        {
            WVertices WVertices = wVertices[i];
            vertices[verticesID + 0] = WVertices.A;
            vertices[verticesID + 1] = WVertices.B;
            vertices[verticesID + 2] = WVertices.C;

            verticesID += 3;
        }

        return vertices;
    }
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
}
