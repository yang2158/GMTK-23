using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class BasicEnemy : MonoBehaviour
{
    private GameObject gameManager;

    public Vector3 ep;
    [SerializeField] private float distanceToGo = 50;
    [SerializeField] private float damage = 5;
    public float speed = 5;
    public float speedMulti = 1;
    float interval = 0;
    public float waveHeight = 0.5f;
    public float waveIntensity = 0.5f;
    public float waveFrequency = 30f;
    public float trueSpeed = 0;
    public float randomSpeedStat = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ep = new Vector3(transform.position.x + distanceToGo, transform.position.y, transform.position.z);
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {


        ep.y = transform.position.y;
        Vector3 dir = ep - transform.position;
        if(dir.magnitude < 0.4f)
        {
            //REACH CASTLE
            gameManager.GetComponent<CastleHealth>().TakeDamage(damage);
            GameObject.Destroy(gameObject);
        }
        dir.Normalize();
        interval = (interval + Time.deltaTime);
        float wave = waveIntensity * Mathf.Cos(waveFrequency/((Mathf.PI * 2)  ) * interval) + waveIntensity + waveHeight;

        trueSpeed = speed * speedMulti * wave;
        transform.position += dir * trueSpeed * Time.deltaTime * Random.Range(0.8f, 1.2f) / 100f;

    }
}
