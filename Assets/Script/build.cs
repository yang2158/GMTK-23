using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour
{
    public static build Instance;
    public Transform ally;
    public GameObject hover = null;
    public GameObject enemies;
    public Transform bullets;
    // Start is called before the first frame update
    int clicks = 0;
    int price=int.MaxValue;
    Object itm;
    public void sel(Object item, int prices )
    {
        if (hover)
        {
            GameObject.Destroy(hover);
        }
        hover = (GameObject)GameObject.Instantiate(item, getMousePos(), Quaternion.identity, ally);
        hover.GetComponent<EnemyDetect>().enemies = enemies;
        hover.GetComponent<EnemyDetect>().bulletLocal = bullets;
        hover.GetComponent<SpriteRenderer>().color = setAlpha(hover.GetComponent<SpriteRenderer>().color, 170);

        clicks = 0;
        hover.GetComponent<EnemyDetect>().canShoot = false;
        hover.GetComponent<EnemyDetect>().canMove = false;
        price = prices;
        itm = item;
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&clicks %2 == 0)
        {
            clicks++;
        }
        if (Input.GetMouseButtonUp(0) && clicks % 2 == 1)
        {
            clicks++;
        }
        if (hover)
        {
            PlayerController.instance.bankDisplay.color = Color.white;
            hover.transform.position = getMousePos();
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Destroy(hover);
                PlayerController.instance.bankDisplay.color = Color.white;

            }
            if (!hover.GetComponent<EnemyDetect>().intersectsOthers())
            {
                if (PlayerController.instance.checkBank(price))
                {
                    hover.GetComponent<SpriteRenderer>().color = setAlpha(hover.GetComponent<SpriteRenderer>().color,170);
                    if (Input.GetMouseButtonUp(0) && clicks >2)
                    {
                        PlayerController.instance.promptBank(price);
                        hover.GetComponent<EnemyDetect>().canShoot = true;
                        hover.GetComponent<EnemyDetect>().canMove = false;
                        hover.GetComponent<SpriteRenderer>().color = setAlpha(hover.GetComponent<SpriteRenderer>().color, 255);
                        hover = null;
                        //Prompt to place more
                        hover = (GameObject)GameObject.Instantiate(itm, getMousePos(), Quaternion.identity, ally);

                        hover.GetComponent<EnemyDetect>().enemies = enemies;
                        hover.GetComponent<EnemyDetect>().bulletLocal = bullets;
                        hover.GetComponent<SpriteRenderer>().color = setAlpha(hover.GetComponent<SpriteRenderer>().color, 170);
                        hover.GetComponent<EnemyDetect>().canShoot = false;
                        hover.GetComponent<EnemyDetect>().canMove = false;

                    }
                }
                else
                {

                    PlayerController.instance.bankDisplay.color = Color.red;
                }
            }
            else
            {
                PlayerController.instance.bankDisplay.color = Color.white;
                if (!PlayerController.instance.checkBank(price))
                    PlayerController.instance.bankDisplay.color = Color.red;
                hover.GetComponent<SpriteRenderer>().color = setAlpha(hover.GetComponent<SpriteRenderer>().color, 100);
            }
        }
        else
        {

            PlayerController.instance.bankDisplay.color = Color.white;
        }
    }
    public Color setAlpha (Color c , int a)
    {
        return new Color ( c.r , c.g , c.b , Mathf.Clamp(a, 0, 255)/255f);
    }
    public Vector3 getMousePos()
    {

        Vector3 input = Input.mousePosition;
        input.z = Camera.main.nearClipPlane + 0.4f;
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
        mousePos.y = Mathf.Clamp(mousePos.y,5f,20f);
        return mousePos;
    }
}
