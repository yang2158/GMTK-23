using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectButton : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update

    private bool hover = false;
    public string infoText;
    public Object prefabObj;
    public int price = 1;
    void Start()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {

        if (hover)
        {

            PlayerController.instance.setInfoText(infoText,price);
        }

    }

    public void OnSelect(BaseEventData eventData)
    {
        build.Instance.sel(prefabObj , price);
    }
    public void clk()
    {
        build.Instance.sel(prefabObj, price);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }
}
