using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform playerBody;
    public Transform cameraBody;
    public Transform groundCheck;
    public KeyCode CameraLock;
    public float mouseSensitivity = 100f;
    public string Xaxis;
    public string Yaxis;
    float zRotation = 0f;
    float yRotation = 0f;


    void Start()
    {
        Xaxis = PlayerPrefs.GetString("ControlSettingX", "Mouse X");
        Yaxis = PlayerPrefs.GetString("ControlSettingY", "Mouse Y");
        mouseSensitivity = PlayerPrefs.GetFloat("CameraSensitivity", 500f);
    }

    void Update()
    {

        float x = Input.GetAxis(Xaxis) * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis(Yaxis) * mouseSensitivity * -1f * Time.deltaTime;

        if (Input.GetKey(CameraLock))
        {
            x = 0f;
            y = 0f;
        }

        zRotation -= y;
        yRotation += x;
        zRotation = Mathf.Clamp(zRotation, -25f, 25f);

        transform.position = playerBody.position;
        groundCheck.position = playerBody.position - new Vector3(0f, 0.5f, 0f);

        cameraBody.rotation = Quaternion.Euler(0f, yRotation, zRotation);
        groundCheck.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
