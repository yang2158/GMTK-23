using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform bowPos;
    float timer;
    [SerializeField] float timeBetweenAttack;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttack)
        {
            //fire arrow
            GameObject.FindGameObjectWithTag("GameController").GetComponent<CastleHealth>().TakeDamage(damage);
            Instantiate(arrow, bowPos.position, bowPos.rotation);
            timer = 0;
        }
    }
}
