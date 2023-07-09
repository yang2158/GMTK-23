using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float deathJump = 200;
    private float endJump = 500;
    public float health = 100;
    public float worth = 10f;
    float timer = 0f;
    bool dead = false;
    [SerializeField] float deathAnimTime = 1f;

    AudioSource audioSrc;
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip die;


    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void shot(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
        else
        {

            audioSrc.clip = hurt;
            audioSrc.Play();
        }
    }

    public void Die()
    {
        audioSrc.clip = hurt;
        audioSrc.Play();
        if (dead) return;

        

        transform.GetComponent<Collider>().enabled = false;
        Rigidbody rb = transform.AddComponent<Rigidbody>();
        rb.AddForceAtPosition(Vector3.up * deathJump, transform.position+new Vector3(Random.Range(-6, 7), 5, Random.Range(-1,1) ));
        if(transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        PlayerController.instance.gainDrop(worth);
        transform.GetComponent<SpriteRenderer>().color *=0.5f;
        transform.GetComponent<SpriteRenderer>().color += Color.red ;
        dead = true;
    }
    public void endreach()
    {
        if (dead) return;
        transform.GetComponent<Collider>().enabled = false;
        Rigidbody rb = transform.AddComponent<Rigidbody>();
        rb.AddForceAtPosition(Vector3.up * endJump*2+ Vector3.right* endJump, transform.position + new Vector3(Random.Range(-12, -6), 1, Random.Range(-1, 1)));
        if (transform.childCount > 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        PlayerController.instance.gainDrop(worth);
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
