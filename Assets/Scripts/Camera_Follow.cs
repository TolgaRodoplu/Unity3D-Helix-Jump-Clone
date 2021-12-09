using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Rigidbody rb;
    Transform Main_Camera;
    float Follow_Speed = -10.5f;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Main_Camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < Follow_Speed)
            Main_Camera.SetParent(transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Main_Camera.parent != null)
        {
            Main_Camera.SetParent(null);
            Vector3 target = new Vector3(0, transform.position.y + 2.86f, Main_Camera.position.z);
            Main_Camera.position = Vector3.Lerp(Main_Camera.position, target, Time.time);
        }
    }

}
