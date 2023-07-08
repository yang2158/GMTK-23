using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float health = 100;
    [SerializeField] Image healthBar;

    public void TakeDamage(float damage)
    {
        Debug.Log(health);
        health -= damage;
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<WindowManager>().GameOverScreen();
        }
    }


}
