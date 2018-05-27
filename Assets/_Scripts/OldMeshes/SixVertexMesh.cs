using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class SixVertexMesh : MonoBehaviour 
{
    [SerializeField]
    private Material meshMat;

    private Vector3[] vertices;
    private int[] triangles;

    private Mesh mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Use this for initialization
    void Update()
    {
        PopulateMeshData();
        DrawTriangle();
    }

    private void PopulateMeshData()
    {
        vertices = new Vector3[] {  new Vector3(0, YValue.Instance.yValue, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), 
                                    new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 1)};
        triangles = new int[] { 0, 1, 2, 3, 4, 5 };
    }

    private void DrawTriangle()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        if (meshMat != null)
        {
            GetComponent<MeshRenderer>().material = meshMat;
        }
    }
}
