using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
    public float speed = 5;
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}