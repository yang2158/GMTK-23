using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
    public GameObject cred;
    int clicks = 0;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(click);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0 ) || Input.GetMouseButtonDown(1))
        {
            clicks++;
            if( clicks >= 2)
            {
                cred.SetActive(false);
                clicks = 0;
            }
        }
    }
    void click()
    {
        
        cred.SetActive(true);
    }
}
