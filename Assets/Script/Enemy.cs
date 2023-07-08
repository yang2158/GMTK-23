using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float deathJump = 200;
    public float health = 100;
    float timer = 0f;
    bool dead = false;
    [SerializeField] float deathAnimTime = 1f;

    public void shot(float dmg)
    {
        health -= dmg;
        if (health <= 0) Die();
    }

    public void Die()
    {
        transform.GetComponent<Collider>().enabled = false;
        Rigidbody rb = transform.AddComponent<Rigidbody>();
        rb.AddForceAtPosition(Vector3.up * deathJump, transform.position+new Vector3(Random.Range(-6, 7), 5, Random.Range(-1,1) ));
<<<<<<< HEAD
        if(transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
=======
>>>>>>> b6befea697a43184ec4aa7a734ae319027ea4cfc
        dead = true;
    }
    private void Update()
    {
        if(timer >= deathAnimTime)
        {
            Destroy(gameObject);
        }
        if(dead) timer += Time.deltaTime;
    }
    public bool IsDead()
    {
        return dead;
    }
}
