using UnityEngine;

public class MeshRenderersTest : MonoBehaviour
{
    public int numberToSpawn = 50000;
    public GameObject prefab;

    void Start()
    {
        Random.InitState(0);
        for (int i = 0; i < numberToSpawn; i++)
        {
            Vector2 posXZ = Random.insideUnitCircle * 2000 + new Vector2(0, 2000);
            Instantiate(prefab, new Vector3(posXZ.x, 0, posXZ.y), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        }
    }
}
