using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;

    public Transform cameraTarget;
    public float sSpeed = 10.0f;
    public Vector3 dist;
    public Transform lookTarget;

    public Light light;

    private void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;

    }
    void FixedUpdate()
    {

        if (Input.GetKeyDown("space"))
        {
            cam1.enabled = false;
            cam2.enabled = true;
            light.enabled = false;

        }
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);

    }
    
}
