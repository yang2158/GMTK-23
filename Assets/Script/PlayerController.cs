using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int piercing=1;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            shoot();
        }
    }
    public void shoot()
    {
        for (int i = 0; i < piercing; i++)
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.transform.GetComponent<Enemy>() != null)
                {

                    hitInfo.collider.transform.GetComponent<Enemy>().shot(100);
                }
            }
        }
    }
}
