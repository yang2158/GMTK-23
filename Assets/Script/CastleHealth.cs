using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float health = 100;
    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarBG;

    [SerializeField] Image hurtIndicator;
    [SerializeField] float alpha;

    [SerializeField] AudioSource audioSrc;

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void FixedUpdate()
    {

        if (healthBarBG)
            healthBarBG.fillAmount = Mathf.Lerp(healthBarBG.fillAmount, healthBar.fillAmount, 0.2f);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        audioSrc.Play();

        Color hurtColor = hurtIndicator.color;
        Color hurtFadeColor = hurtColor;
        hurtFadeColor.a = alpha;
        LeanTween.value(gameObject, updateValue, hurtColor, hurtFadeColor, 1f);
        LeanTween.delayedCall(0.1f, HurtFadeOut);

        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<WindowManager>().GameOverScreen();
        }

    }
    void updateValue(Color val) {
        hurtIndicator.color = val;
    }
    void HurtFadeOut()
    {
        Color hurtColor = hurtIndicator.color;
        Color hurtFadeColor = hurtColor;
        hurtFadeColor.a = 0;
        LeanTween.value(gameObject, updateValue, hurtColor, hurtFadeColor, 1f);
    }

}
