using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class DrawMeshInstancedTest : MonoBehaviour
{
    public int numberToSpawn = 50000;
    public GameObject prefab;

    Mesh mesh;
    Material material;
    List<Vector3> positions = new List<Vector3>();
    List<List<Matrix4x4>> matrices = new List<List<Matrix4x4>>();

    void Start()
    {
        Random.InitState(0);
        mesh = prefab.GetComponent<MeshFilter>().sharedMesh;
        material = prefab.GetComponent<MeshRenderer>().sharedMaterial;
        matrices.Add(new List<Matrix4x4>());
        
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector2 posXZ = Random.insideUnitCircle * 2000 + new Vector2(0, 2000);
            matrices[matrices.Count - 1].Add(Matrix4x4.TRS(new Vector3(posXZ.x, 0, posXZ.y), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f), Vector3.one));

            if (matrices[matrices.Count - 1].Count > 1000)
            {
                matrices.Add(new List<Matrix4x4>());
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < matrices.Count; i++)
        {
            Graphics.DrawMeshInstanced(mesh, 0, material, matrices[i], null, ShadowCastingMode.On);
        }
    }
}
