using UnityEngine;

public class WMesh
{
    public string Name;
    public Vector3[] Vertices;
    public Vector3[] Normals;
    public Vector2[] UV;
    public int[] Triangles;

    public Mesh Mesh
    {
        get { return SetMesh(); }
    }

    public WMesh(WVertices[] Vertices, Vector3[] Normals, Vector2[] UV, WOrderOfVertices[] Triangles, string Name = "Mesh")
    {
        this.Vertices = WMeshHelper.WVerticesToVertices(Vertices);
        this.Triangles = WMeshHelper.WOrderOfVerticesToTriangles(Triangles);
        this.Normals = Normals;
        this.UV = UV;
        this.Name = Name;
    }

    private Mesh SetMesh()
    {
        return new Mesh()
        {
            vertices = Vertices,
            normals = Normals,
            uv = UV,
            triangles = Triangles
        };
    }

    public GameObject CreateMesh(Material material)
    {
        GameObject gameObject = new GameObject(this.Name);
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        Mesh.RecalculateNormals();
        meshFilter.mesh = this.Mesh;
        return gameObject;
    }

    public void ClearMesh(GameObject gameObject)
    {
        gameObject.GetComponent<MeshFilter>().mesh.Clear();
    }
}
