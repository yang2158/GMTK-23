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
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {


        ep.y = transform.position.y;
        Vector3 dir = ep - transform.position;
        dir -= Vector3.forward*dir.z;

        dir -= Vector3.up * dir.y;
        if (dir.magnitude < 0.4f)
        {
            //REACH CASTLE
            if(this.GetComponent<Enemy>().IsDead() == false)
            {
                gameManager.GetComponent<CastleHealth>().TakeDamage(damage);
                transform.GetComponent<Enemy>().endreach();
            }
            
        }
        dir.Normalize();
        interval = (interval + Time.deltaTime);
        float wave = waveIntensity * Mathf.Cos(waveFrequency/((Mathf.PI * 2)  ) * interval) + waveIntensity + waveHeight;

        trueSpeed = speed * speedMulti * wave;
        transform.position += dir * trueSpeed * Time.deltaTime * Random.Range(0.8f, 1.2f) / 100f;

    }
}
