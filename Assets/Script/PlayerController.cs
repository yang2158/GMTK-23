using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public float timer = float.PositiveInfinity;


    //Constant Values
    [SerializeField] private int damage=100;
    public TextMeshProUGUI infoPanel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        timer -= Time.deltaTime;
        if (timer <= 0 && auto > 0)
        {
            timer = auto;
            shoot();
        }
        if (Input.GetMouseButtonUp(0))
            shoot();
        
        infoPanel.text = "Hover Over Buttons for More Info";
    }
    public void shoot()
    {
        float truePierce = PlayerController.floatToInt(piercing);
        for (int i = 0; i < truePierce; i++)
        {
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.transform.GetComponent<Enemy>() != null)
                {
                    hitInfo.collider.transform.GetComponent<Enemy>().shot(damage);
                }
            }
        }
    }

    public int gainDrop(float n)
    {
        money += n * dropMulti;
        return Mathf.FloorToInt(money);
    }
    public static int floatToInt(float n)
    {
        //Coverts a float to a problicmatically correct int
        // i prob spelled problicmatically wrong but idc
        return Mathf.FloorToInt(n) +  ((n - Mathf.Floor(n) > Random.Range(0,1)  )? 1:0 );
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
                dropMulti += 0.1f;
                if (dropMulti < 3)
                {
                    dropMulti += 0.1f;
                }
                return;
        }

    }
    public void setInfoText(string text)
    {
        infoPanel.text = text;
    }
}
