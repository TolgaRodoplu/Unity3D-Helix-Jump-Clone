using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    bool canBounce = true;
    float Bounce_Force = 8f;
    float Gravity_Force = -9.81f;
    float Gravity_Scale = 3f;
    float Clamp_Max = 10f;
    float Clamp_Min = -15f;

    Vector3 Gravity;
    Vector3 Bounce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Gravity = Gravity_Force * Gravity_Scale * Vector3.up;
        Bounce = transform.up * Bounce_Force;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Gravity , ForceMode.Acceleration);
        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, Clamp_Min, Clamp_Max), 0);
        //Debug.Log(rb.velocity.y);
        if (rb.velocity.y < 0 && !canBounce)
            canBounce = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Disk") && canBounce)
        {
            canBounce = false;
            Jump();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        canBounce = false;
    }
    public void Jump()
    {
        FindObjectOfType<AudioManeger>().PlaySound("Bounce");
        rb.AddForce(Bounce, ForceMode.Impulse);
    }
}
