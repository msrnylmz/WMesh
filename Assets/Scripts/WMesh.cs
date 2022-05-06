using UnityEngine;

public class WMesh
{
    public string Name;
    public Vector3[] Vertices;
    public Vector3[] Normals;
    public Vector2[] UV;
    public int[] Triangles;

    public GameObject gameo;
    public MeshFilter meshFilter;

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

    public Mesh SetMesh()
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
        gameo = new GameObject(Name == "" ? this.Name : Name);
        gameo.transform.position = new Vector3(-0.5f, 0.5f, 0.5f);
        meshFilter = gameo.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameo.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        meshFilter.mesh = this.Mesh;
        return gameo;
    }
    public void SetGameObjectMesh()
    {
        meshFilter.mesh = this.Mesh;
    }



    public void ClearMesh(GameObject gameObject)
    {
        gameObject.GetComponent<MeshFilter>().mesh.Clear();
    }
}
