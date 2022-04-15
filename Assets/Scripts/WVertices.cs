using UnityEngine;

public class WVertices 
{
    public Vector3 A, B, C;
    public Vector3[] Vertices
    {
        get
        {
            return new Vector3[3] { A, B, C };
        }
    }

    public WVertices(Vector3 A, Vector3 B, Vector3 C)
    {
        this.A = A;
        this.B = B;
        this.C = C;
    }
}
