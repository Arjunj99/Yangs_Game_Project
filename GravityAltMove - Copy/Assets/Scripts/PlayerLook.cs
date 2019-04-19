using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private GameObject playerBody;
    [SerializeField] private GameObject rotateAttachment;

    public float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotationVert();
    }

    private void CameraRotationVert()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp >= 120 )
        {
            xAxisClamp = 120;
            mouseY = 0.0f;
        }

        if(xAxisClamp <= -120 )
        {
            xAxisClamp = -120;
            mouseY = 0.0f;
        }

        transform.Rotate(Vector3.left * mouseY);
        rotateAttachment.transform.Rotate(Vector3.up * mouseX);
        playerBody.transform.Rotate(Vector3.up * mouseX);

        


        
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}

//compare forward axis of camera to up axis of body. If match, freeze upwards pitch