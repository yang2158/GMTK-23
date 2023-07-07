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
        hover = (GameObject)GameObject.Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, ally);
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
        if (hover)
        {
            hover.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Vector3.forward * Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Destroy(hover);

            }
            if (  enemies.transform.childCount==0 )
            {
                if (hover)
                {
                    hover.GetComponent<SpriteRenderer>().color = Color.green;
                    if (Input.GetMouseButtonUp(0))
                    {
                        hover = (GameObject)GameObject.Instantiate(itm, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, ally);
                        
                    }
                }
            }
            else
            {
                if(hover)
                    hover.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
