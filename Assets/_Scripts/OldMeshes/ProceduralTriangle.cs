using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ProceduralTriangle : MonoBehaviour 
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
    void Start () 
    {
        PopulateMeshData();
        DrawTriangle();
	}

    private void PopulateMeshData()
    {
        vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0) };
        triangles = new int[] { 0, 1, 2};
    }

    private void DrawTriangle()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        if(meshMat != null)
        {
            GetComponent<MeshRenderer>().material = meshMat;
        }
    }
}
