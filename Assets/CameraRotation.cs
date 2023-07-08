using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform castle;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(castle.position, Vector3.down, rotationSpeed*Time.deltaTime);
    }
}
