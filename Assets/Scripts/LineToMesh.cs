using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class LineToMesh : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private MeshFilter meshFilter;
    private Mesh mesh;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        CreateMeshFromLineRenderer();
    }

    void CreateMeshFromLineRenderer()
    {
        Vector3[] vertices = new Vector3[lineRenderer.positionCount * 2];
        int[] triangles = new int[(lineRenderer.positionCount - 1) * 6];

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            vertices[i * 2] = lineRenderer.GetPosition(i) - transform.position;
            vertices[i * 2 + 1] = lineRenderer.GetPosition(i) - transform.position;

            if (i > 0)
            {
                int triIndex = (i - 1) * 6;
                triangles[triIndex] = (i - 1) * 2;
                triangles[triIndex + 1] = (i - 1) * 2 + 1;
                triangles[triIndex + 2] = i * 2;
                triangles[triIndex + 3] = i * 2;
                triangles[triIndex + 4] = (i - 1) * 2 + 1;
                triangles[triIndex + 5] = i * 2 + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}