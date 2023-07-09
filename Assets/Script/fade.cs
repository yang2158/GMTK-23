using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, gameObject.GetComponent<Image>().color.a - (0.5f * Time.deltaTime));
        if(gameObject.GetComponent<Image>().color.a < 0.1)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
