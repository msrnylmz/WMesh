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
    public WMesh(string Name = "Mesh")
    {
        this.Name = Name;
    }
    public WMesh(Vector3[] Vertices, Vector3[] Normals, Vector2[] UV, WOrderOfVertices[] Triangles, string Name = "Mesh")
    {
        this.Vertices = Vertices;
        this.Triangles = WMeshHelper.WOrderOfVerticesToTriangles(Triangles);
        //this.Normals = Normals;
        //this.UV = UV;
        this.Name = Name;
    }

    private Mesh SetMesh()
    {
        Mesh wMesh = new Mesh()
        {
            vertices = Vertices,
            //normals = Normals,
            //uv = UV,
            triangles = Triangles
        };
        wMesh.RecalculateNormals();
        return wMesh;
    }

    public GameObject CreateMesh(Material material, string Name = "")
    {
        GameObject gameObject = new GameObject(Name == "" ? this.Name : Name);
        gameObject.transform.position = new Vector3(-0.5f, 0.5f, 0.5f);
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        meshFilter.mesh = this.Mesh;
        return gameObject;
    }

    public void ClearMesh(GameObject gameObject)
    {
        gameObject.GetComponent<MeshFilter>().mesh.Clear();
    }
}
