using UnityEngine;

public class SunRotator : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        float rot = transform.rotation.eulerAngles.y + 30f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(50, rot, 0);
    }
}
