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

    int timesBought = 0;
    public int cost;
    

    // Update is called once per frame
    void LateUpdate()
    {

        if (hover)
        {

            PlayerController.instance.setInfoText(infoText,cost);
        }

    }

    public void cliked()
    {
        if (PlayerController.instance.promptBank(cost))
        {
            PlayerController.instance.upgradeID(upgradeID);
            cost += 8;
        }

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
