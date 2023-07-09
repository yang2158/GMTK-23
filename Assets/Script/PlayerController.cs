using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using UnityEditor.PackageManager;
using System;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;



    //Stat Values
    public float piercing=1;
    public float  dmgMultiplier = 1;
    public float dropMulti = 1;
    public float auto = 0;



    //Game Values
    public float money = 0;
    public float displayedMoney = 0;
    public float timer = float.PositiveInfinity;



    //Game Stats
    public int emyKilled = 0;
    public float earned = 0; 
    public System.DateTime startTime = System.DateTime.Now;

    //Constant Values
    [SerializeField] private int damage=100;
    [SerializeField] Image bulletBar;
    public TextMeshProUGUI infoPanel;
    public TextMeshProUGUI infoCostPanel;
    [SerializeField] private TextMeshProUGUI[] statBGDisplay= new TextMeshProUGUI[4];
    [SerializeField] public TextMeshProUGUI bankDisplay ;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startTime = DateTime.Now ;

    }

    // Update is called once per frame
    void Update()
    {
        displayedMoney = Mathf.Lerp(money, displayedMoney, 0.5f);
        if (bankDisplay)
        {
            
            if (displayedMoney < int.MaxValue)
            {
                bankDisplay.text = "Coins: " + Mathf.RoundToInt(displayedMoney);
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0 && auto > 0)
        {
            timer = 1/auto;
            shoot();
        }
        if (Input.GetMouseButtonUp(0))
            shoot();
        float amt = timer * auto;
        if(!float.IsNaN(amt))
            bulletBar.fillAmount =amt;
        infoPanel.text = "Hover Over Buttons for More Info";
        infoCostPanel.text = "Cost: ???";
        setBGIDText(1);
        setBGIDText(2);
        setBGIDText(3);
        setBGIDText(4);
    }
    public void shoot()
    {
        int canHit = PlayerController.floatToInt(piercing);
            RaycastHit[] hitInfo = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (hitInfo!=null)
            {
                foreach( RaycastHit hit in hitInfo)
                {
                    if (hit.collider.transform.GetComponent<Enemy>() != null && canHit>0)
                    {
                        canHit--;
                        hit.collider.transform.GetComponent<Enemy>().shot(damage);
                    }
                }
                
            }
        
    }

    public int gainDrop(float n)
    {
        earned += n * dropMulti;
        money += n * dropMulti;
        emyKilled++;
        return Mathf.FloorToInt(money);
    }
    public static int floatToInt(float n)
    {
        //Coverts a float to a problicmatically correct int
        // i prob spelled problicmatically wrong but idc
        return Mathf.FloorToInt(n) +  ((n - Mathf.Floor(n) > UnityEngine.Random.Range(0,1)  )? 1:0 );
    }
    public void upgradeID(int id)
    {
        switch(id )
        {
            case 1:
                piercing+=0.1f;
                if(piercing < 3)
                {
                    piercing += 0.1f;
                }
                return;
            case 2:
                dmgMultiplier += 0.1f;
                if (dmgMultiplier < 3)
                {
                    dmgMultiplier += 0.1f;
                }
                return;
            case 3:
                dropMulti += 0.1f;
                if (dropMulti < 3)
                {
                    dropMulti += 0.1f;
                }
                return;
            case 4:
                auto += 0.1f;
                if (auto < 3)
                {
                    auto += 0.1f;
                }
                if(timer !=0)
                timer = bulletBar.fillAmount / auto;
                return;
        }

    }

    public bool promptBank(float price )
    {
        if (price > money) return false;
        money -= price;
        return true;
    }
    public bool checkBank(float price)
    {
        if (price > money) return false;
        return true;
    }
    public void setBGIDText(int id)
    {
        if (id < 1 || id > 4) return;
        float value = auto;

        switch (id)
        {
            case 1:
                value = piercing;
                break;
            case 2:
                value = dmgMultiplier;
                break;
            case 3:
                value = dropMulti;
                break;
        }
        statBGDisplay[id - 1].text = "x"+ string.Format("{0:0.0}", value);
    }
    public void setInfoText(string text)
    {
        infoPanel.text = text;
    }
    public void setInfoText(string text, float cost)
    {
        setInfoText(text);
        infoCostPanel.text = "Cost: " + Mathf.RoundToInt(cost+0.5f);
    }
}
