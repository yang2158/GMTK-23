using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class upgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool hover = false;
    public int upgradeID = 000;
    public string infoText;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (hover)
        {

            PlayerController.instance.setInfoText(infoText);
        }

    }

    public void cliked()
    {
        PlayerController.instance.upgradeID(upgradeID);
        Debug.Log("Upgraded ID:" + upgradeID);

    }
    void OnPointerEnter(PointerEventData eventData)
    {
       hover = true;

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
