using UnityEngine;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private Material m_MeshMaterial;
    [SerializeField] private string m_CubeMeshName;
    private WPlane m_Plane;

    [Space]

    [Range(1, 100)]
    public int Height;
    [Range(1, 100)]
    public int Width;
    [Range(1, 100)]
    public int UnitLenght;

    private WMesh m_PlaneMesh;

    [Space]

    [Header("Perlin Noise Effect")]
    [Range(0.00001f, 100)]
    public float Scale;
    [Range(0.00001f, 100)]
    public float HeightMultiplier;
    [Range(0.00001f, 100)]
    public float Offset;

    private void Start()
    {
        Initialize();
    }
    private void Update()
    {
        Controller();
    }

    private void Initialize()
    {
        m_PlaneMesh = new WMesh();
        m_Plane = new WPlane(ref m_PlaneMesh, Width, Height, UnitLenght);
        m_PlaneMesh.CreateMesh(m_MeshMaterial, "Plane " + Height + "x" + Width);
        CreateCube();
    }

    private void Controller()
    {
        m_Plane.PerlinNoiseEffect(Scale, HeightMultiplier, Offset);
        m_PlaneMesh.SetGameObjectMesh();
    }

    private void CreateCube()
    {
        Vector3[] wVertices = new Vector3[]
 {
        new Vector3(0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, -0.5f, 0.5f),
        new Vector3(0.5f, 0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, 0.5f),
        new Vector3(0.5f, 0.5f, -0.5f),
        new Vector3(-0.5f, 0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, -0.5f),
        new Vector3(-0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, 0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, 0.5f),
        new Vector3(0.5f, 0.5f, -0.5f),
        new Vector3(-0.5f, 0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, -0.5f, -0.5f),
        new Vector3(-0.5f, -0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, 0.5f),
        new Vector3(-0.5f, 0.5f, -0.5f),
        new Vector3(-0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, -0.5f, -0.5f),
        new Vector3(0.5f, 0.5f, -0.5f),
        new Vector3(0.5f, 0.5f, 0.5f),
        new Vector3(0.5f, -0.5f, 0.5f),
 };


        WOrderOfVertices[] wOrderOfVertices = new WOrderOfVertices[]
        {
            new WOrderOfVertices ( 0, 2, 3),
            new WOrderOfVertices ( 0, 3, 1),
            new WOrderOfVertices ( 8, 4, 5),
            new WOrderOfVertices ( 8 ,5, 9),
            new WOrderOfVertices ( 10, 6, 7),
            new WOrderOfVertices ( 10, 7, 11),
            new WOrderOfVertices ( 12 ,13, 14),
            new WOrderOfVertices ( 12, 14, 15),
            new WOrderOfVertices ( 16 ,17 ,18),
            new WOrderOfVertices ( 16, 18, 19),
            new WOrderOfVertices ( 20, 21, 22),
            new WOrderOfVertices ( 20 ,22 ,23),
        };

        WMesh wMesh = new WMesh(wVertices, null, null, wOrderOfVertices, m_CubeMeshName);
        wMesh.CreateMesh(m_MeshMaterial);
    }
}
