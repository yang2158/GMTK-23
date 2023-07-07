using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class BasicEnemy : MonoBehaviour
{
    public GameObject endPos ;
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
        randomSpeedStat = Random.Range(0.8f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 ep = endPos.transform.position;
        ep.y = transform.position.y;
        Vector3 dir = ep - transform.position;
        if(dir.magnitude < 0.4f)
        {
            //REACH CASTLE
            GameObject.Destroy(gameObject);
        }
        dir.Normalize();
        interval = (interval + Time.deltaTime);
        float wave = waveIntensity * Mathf.Cos(waveFrequency/((Mathf.PI * 2)  ) * interval) + waveIntensity + waveHeight;

        trueSpeed = speed * speedMulti * wave;
        transform.position += dir * trueSpeed * Time.deltaTime * randomSpeedStat / 100f;

    }
}
