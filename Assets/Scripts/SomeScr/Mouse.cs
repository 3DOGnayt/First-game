using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float mousesens = 100f;
    public Transform playerBody;
    float xRot = 0f;   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
        
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousesens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -75f, 60f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
