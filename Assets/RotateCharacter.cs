using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    public float rotateSpeed = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}