using System.Collections.Generic;
using UnityEngine;

public class DrawMeshTest : MonoBehaviour
{
    public int numberToSpawn = 50000;
    public GameObject prefab;

    Mesh mesh;
    Material material;
    List<Matrix4x4> matrices = new List<Matrix4x4>();

    void Start()
    {
        Random.InitState(0);
        mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
        material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
        
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector2 posXZ = Random.insideUnitCircle * 2000 + new Vector2(0, 2000);
            matrices.Add(Matrix4x4.TRS(new Vector3(posXZ.x, 0, posXZ.y), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), Vector3.one));
        }
    }

    void Update()
    {
        for (int i = 0; i < matrices.Count; i++)
        {
            Graphics.DrawMesh(
                mesh,
                matrices[i],
                material,
                0,
                null,
                0,
                null,
                true
            );
        }
    }
}
