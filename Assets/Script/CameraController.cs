using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 1;
    public float zoomSpeed = 30;
    public float TargetPos = 0;
    public float TargetZoom = 0;
    public float lerpSmooth = 0.1f;
    public float lerpSmoothZ = 0.02f;
    public Vector2 zoomRange;
    public Vector2 xRange;
    Camera cam = null;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        TargetZoom = transform.position.z;
        TargetPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zoom = Input.GetAxis("Mouse ScrollWheel") + Input.GetAxis("Vertical")*0.02f; 
        TargetZoom += zoom*zoomSpeed;
        TargetPos += xAxis* cameraSpeed;
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(transform.position.x, TargetPos, lerpSmooth); 
        pos.z = Mathf.Lerp(transform.position.z, TargetZoom, lerpSmoothZ);
        transform.position = pos; 
    }
}
