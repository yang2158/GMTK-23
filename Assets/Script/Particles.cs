using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private Transform particle;
    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        particle.position = new Vector3(camPos.x, camPos.y, 0);
    }
}
