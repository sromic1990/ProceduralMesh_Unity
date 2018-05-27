using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour 
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    //grid settings
    public float cellSize = 1;
    public Vector3 gridOffset;
    public int gridSize;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Use this for initialization
    void Start () 
    {
        MakeContiguousProceduralGrid();
        UpdateMesh();
	}

    //private void MakeDiscreteProceduralGrid()
    //{
    //    //setting array sizes
    //    vertices = new Vector3[gridSize * gridSize * 4];
    //    triangles = new int[gridSize * gridSize * 6];
    //
    //    //set tracker integers
    //    int v = 0, t = 0; 
    //
    //    //set vertex offset
    //    float vertexOffset = cellSize * 0.5f;
    //
    //    for (int x = 0; x < gridSize; x++)
    //    {
    //        for (int z = 0; z < gridSize; z++)
    //        {
    //            Vector3 cellOffset = new Vector3(x * cellSize, 0, z* cellSize);
    //
    //            //populate the vertices and triangles arrays
    //            vertices[v] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset + gridOffset;
    //            vertices[v + 1] = new Vector3(-vertexOffset, 0, vertexOffset) + cellOffset + gridOffset;
    //            vertices[v + 2] = new Vector3(vertexOffset, 0, -vertexOffset) + cellOffset + gridOffset;
    //            vertices[v + 3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset + gridOffset;
    //
    //            triangles[t] = v;
    //            triangles[t + 1] = triangles[t + 4] = v + 1;
    //            triangles[t + 2] = triangles[t + 3] = v + 2;
    //            triangles[t + 5] = v + 3;
    //
    //            v += 4;
    //            t += 6;
    //        }
    //    }
    //}

    private void MakeContiguousProceduralGrid()
    {
        //setting array sizes
        vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
        triangles = new int[gridSize * gridSize * 6];

        //set tracker integers
        int v = 0, t = 0;

        //set vertex offset
        float vertexOffset = cellSize * 0.5f;

        //create vertex grid
        for (int x = 0; x <= gridSize; x++)
        {
            for (int z = 0; z <= gridSize; z++)
            {
                vertices[v] = new Vector3((x * cellSize) - vertexOffset, 0,  (z * cellSize) - vertexOffset);
                v++;
            }
        }

        //reset vertex tracker
        v = 0;

        //setting each cell's triangles
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + (gridSize + 1);
                triangles[t + 5] = v + 1 + (gridSize + 1);

                v++;
                t += 6;
            }
            v++;
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
