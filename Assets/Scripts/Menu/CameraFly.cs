using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFly : MonoBehaviour
{
    public Transform target; 
    public float radius = 10f; 
    public float speed = 2f; 

    private Vector3 offset; 

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        float angle = Time.time * speed; 
        Vector3 circlePos = target.position + new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
        transform.position = circlePos;

        transform.LookAt(target);
    }
}
