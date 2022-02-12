using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        RotateInput();
    }

    private void RotateInput()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, -_horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
