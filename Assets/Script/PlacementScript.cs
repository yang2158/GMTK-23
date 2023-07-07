using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlacementScript : MonoBehaviour
{

    Vector3 pos = Vector3.zero;
    SpriteRenderer sr = null;
    // Start is called before the first frame update
    void Start()
    {
        sr =    transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color c = sr.color;

        c.a = 170f/255f;
        sr.color = c;
        Vector3 input = Input.mousePosition;
        input.z = Camera.main.nearClipPlane+0.4f;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // create a plane at 0,0,0 whose normal points to +Y:
        Plane hPlane = new Plane(Vector3.forward, Vector3.zero);
        // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        float distance = 0;
        // if the ray hits the plane...

        Vector3 mousePos = transform.position;
        if (hPlane.Raycast(ray, out distance))
        {
            // get the hit point:
            mousePos = ray.GetPoint(distance);
        }
        mousePos.y = 0.5f;
        mousePos.x = Mathf.FloorToInt(mousePos.x) + 0.5f;
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = mousePos;
            c.a = 1;
            sr.color = c;
            GameObject.Destroy(this);

        }
        transform.position = Vector3.Lerp(transform.position , mousePos ,0.3f);
    }
}
