using UnityEngine;
public class WPlane : WShape
{
    private int m_Width;
    private int m_Height;
    private int m_UnitLenght;
    private float m_NoiseEffectOffset;

    public WPlane(ref WMesh Mesh, int Width, int Height, int UnitLenght) : base(Mesh)
    {
        m_Width = Width;
        m_Height = Height;
        m_UnitLenght = UnitLenght;
        Set();
    }

    private void Set()
    {
        SetVertices();
        SetTriangles();
    }

    private void SetVertices()
    {
        Vector3 vertexPosition = Vector3.zero;
        int verticesLenght = (m_Width + 1) * (m_Height + 1);
        m_Mesh.Vertices = new Vector3[verticesLenght];

        for (int vertexIndex = 0, h = 0; h <= m_Height; h++)
        {
            for (int w = 0; w <= m_Width; w++)
            {
                vertexPosition = Vector3.right * w * m_UnitLenght + Vector3.forward * h * m_UnitLenght;
                m_Mesh.Vertices[vertexIndex] = vertexPosition;
                vertexIndex++;
            }
        }
    }

    public void PerlinNoiseEffect(float scale, float heightMultiplier, float offset)
    {
        m_NoiseEffectOffset += offset;

        Vector3 vertexPosition = Vector3.zero;
        int verticesLenght = (m_Width + 1) * (m_Height + 1);
        m_Mesh.Vertices = new Vector3[verticesLenght];

        for (int vertexIndex = 0, h = 0; h <= m_Height; h++)
        {
            for (int w = 0; w <= m_Width; w++)
            {
                vertexPosition = (Vector3.right * w * m_UnitLenght) + (Vector3.forward * h * m_UnitLenght);
                vertexPosition += Vector3.up * WMeshHelper.WGenerateNoise(w, h, scale, vertexPosition, m_NoiseEffectOffset) * heightMultiplier;
                m_Mesh.Vertices[vertexIndex] = vertexPosition;
                vertexIndex++;
            }
        }
    }

    private void SetTriangles()
    {
        int[] triangles = new int[m_Width * m_Height * 6];
        int verticesCount = 0;
        int trianglesCount = 0;

        for (int h = 0; h < m_Height; h++)
        {
            for (int w = 0; w < m_Width; w++)
            {
                triangles[trianglesCount + 0] = verticesCount + 0;
                triangles[trianglesCount + 1] = verticesCount + m_Width + 1;
                triangles[trianglesCount + 2] = verticesCount + 1;
                triangles[trianglesCount + 3] = verticesCount + 1;
                triangles[trianglesCount + 4] = verticesCount + m_Width + 1;
                triangles[trianglesCount + 5] = verticesCount + m_Width + 2;

                verticesCount++;
                trianglesCount += 6;
            }
            verticesCount++;
        }
        m_Mesh.Triangles = triangles;
    }
}
