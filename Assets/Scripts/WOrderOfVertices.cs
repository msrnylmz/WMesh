using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WOrderOfVertices
{
    public int A, B, C;
    public int[] Triangle
    {
        get
        {
            return new int[3] { A, B, C };
        }
    }

    public WOrderOfVertices(int A, int B, int C)
    {
        this.A = A;
        this.B = B;
        this.C = C;
    }
}
