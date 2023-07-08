using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float timeToDestroy;
    float timer=0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > timeToDestroy) Destroy(gameObject);
    }
}
