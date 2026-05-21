using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    
void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}
   
    public void ProcessLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;
        //kalkulasi rotasi kamera untuk melihat atas dan bawah
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply ke camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // rotasi player melihat kiri dan kanan
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) *xSensitivity);
    }
}
