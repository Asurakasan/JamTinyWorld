using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIa : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public Transform tf;
    private Vector3 direction = Vector3.zero;
    float time = 0;

    void Start()
    {
        direction = Random.insideUnitSphere;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > 2)
        {
            direction = Random.insideUnitSphere;
            transform.rotation = Quaternion.Euler(direction.x, direction.y, direction.z);
            time = 0;
        }
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

}
