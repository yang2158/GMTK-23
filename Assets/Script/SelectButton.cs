using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectButton : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update

    public Object prefabObj;
    public int price = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera main = Camera.main;
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        // OnMouseOver
        if (Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.collider.gameObject == gameObject)
            {
                transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().enabled = true;

            }
            else
            {
                transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
            }
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        build.Instance.sel(prefabObj , price);
       
    }
     void OnMouseEnter()
    {
            transform.GetChild(0).GetComponent<Text>().enabled = true;
        
    }
      void OnMouseExit()
    {
            transform.GetChild(0).GetComponent<Text>().enabled = false;
        
    }
    private void OnMouseOver()
    {
        transform.GetChild(0).GetComponent<Text>().enabled = false;
    }
}
