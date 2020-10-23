using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        rotationSpeed += Time.deltaTime;
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
