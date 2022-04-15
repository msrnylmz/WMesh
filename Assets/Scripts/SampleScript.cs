using UnityEngine;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private Material m_MeshMaterial;
    [SerializeField] private string m_MeshName;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        WVertices[] wVertices = new WVertices[1]
        {
            new WVertices
            (
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 0)
            )
        };

        WOrderOfVertices[] wOrderOfVertices = new WOrderOfVertices[2]
        {
            new WOrderOfVertices (0, 1, 2),
            new WOrderOfVertices (2, 1, 0)
        };

        WMesh wMesh = new WMesh(wVertices, null, null, wOrderOfVertices, m_MeshName);
        wMesh.CreateMesh(m_MeshMaterial);
    }
}
