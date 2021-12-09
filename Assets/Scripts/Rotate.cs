using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float Rotation_Scale = 60f;

    void Update()
    {
        Rotating();
    }

    void Rotating()
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.x, -Mathf.PingPong(Time.time * Rotation_Scale, 60f), transform.rotation.z);
    }
}

