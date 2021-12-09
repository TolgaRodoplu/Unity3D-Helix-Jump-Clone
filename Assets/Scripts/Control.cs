using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    
    
    public float Rotate_Speed = 0.5f;
    Vector3 Rotate;
    

    // Update is called once per frame
    private void Start()
    {
        Rotate = new Vector3(0f, Rotate_Speed, 0f);
    }

    void Update()
    {
        
        if (Input.GetKey("a"))
            gameObject.transform.Rotate(Rotate, Space.Self);

        if (Input.GetKey("d"))
            gameObject.transform.Rotate(-Rotate, Space.Self);
    }
    
    


    //Input With Mouse
    /*
    float mouseX;
    float mouseY;
    public float mouseSensitivity = 600f;
    bool isPaused = false;

    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        if (Input.GetMouseButton(0) && !isPaused)
        {
            Debug.Log("saaq");
            transform.Rotate(Vector3.up * mouseX);
        }
    }
    */
}
