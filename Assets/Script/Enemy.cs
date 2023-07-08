using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float deathJump = 200;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shot(float dmg)
    {
        health -= dmg;
        if (health <= 0) die();
    }

    public void die()
    {
        transform.GetComponent<Collider>().enabled = false;
        Rigidbody rb = transform.AddComponent<Rigidbody>();
        rb.AddForceAtPosition(Vector3.up * deathJump, transform.position+new Vector3(Random.Range(-6, 7), 5, Random.Range(-1,1) ));

    }
}
