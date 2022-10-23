using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}