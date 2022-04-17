using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class WPlaneMeshGenerator : MonoBehaviour
{
    private WMesh m_Mesh;
    private Vector3[] m_Vertices;
    private WOrderOfVertices[] m_OrderOfvertices;
    [SerializeField] private Material m_PlaneMaterial;

    [Range(1, 100)]
    public int Square;
    public int UnitLenght;
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        GeneratePlane(Square, UnitLenght);
    }

    public void GeneratePlane(int Square, int UnitLenght)
    {
        int verticesLenght = Square * Square;
        m_Vertices = new Vector3[verticesLenght];

        int orderOfVerticesLenght = ((Square - 1) * (Square - 1)) * 2;
        m_OrderOfvertices = new WOrderOfVertices[orderOfVerticesLenght];

        int verticesIndex = 0;
        int orderOfVerticesIndex = 0;
        Vector3 vertexPosition = Vector3.zero;

        GameObject parentOfCubes = new GameObject("Parent");

        for (int w = 0; w < Square; w++)
        {
            for (int h = 0; h < Square; h++)
            {
                vertexPosition = Vector3.right * w * UnitLenght + Vector3.forward * h * UnitLenght;
                m_Vertices[verticesIndex] = vertexPosition;

                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.transform.localScale = new Vector3(100, 100, 100);
                gameObject.transform.position = vertexPosition + Vector3.up * 50.5f;
                gameObject.transform.parent = parentOfCubes.transform;

                if (w != Square - 1 && h != Square - 1)
                {
                    m_OrderOfvertices[orderOfVerticesIndex]
                    = new WOrderOfVertices(verticesIndex + Square + 1, verticesIndex + Square, verticesIndex);

                    m_OrderOfvertices[orderOfVerticesIndex + 1]
                    = new WOrderOfVertices(verticesIndex + 1, verticesIndex + Square + 1, verticesIndex);

                    orderOfVerticesIndex += 2;
                }

                verticesIndex++;
            }
        }

        WMesh wMesh = new WMesh(m_Vertices, null, null, m_OrderOfvertices, "Plane " + Square + "x" + Square);
        wMesh.CreateMesh(m_PlaneMaterial);
    }
}
