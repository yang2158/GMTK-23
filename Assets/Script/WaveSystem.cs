using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] t1enemies;
    [SerializeField] private GameObject[] t2enemies;
    [SerializeField] private GameObject[] t3enemies;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private TMP_Text waveText;
    public float deathZ = 0;
    public float rngRangeX = 10;
    [SerializeField] private int startPosX;
    [SerializeField] private int minZ;
    [SerializeField] private int maxZ;


    //[SerializeField] private int enemiesAlive;
    [SerializeField] private int slope;

    public static WaveSystem instance;
    [SerializeField] private int waveNum = 0;

    void StartWave()
    {
        waveNum++;
        waveText.text = "Wave " + waveNum;
        int waveSize = waveNum;
        GameObject[] enemies= t1enemies;
        if (waveNum >=10)
        {
            waveSize -= 10;
            enemies = concat(enemies,t2enemies);
        }
        if (waveNum >=20)
        {
            waveSize -= 10;
            enemies = concat(enemies, t3enemies);
        }
        for (int i = 0; i < waveSize * slope; i++)
        {

            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            GameObject newEnemy = Instantiate(enemy, enemiesParent);
            Vector3 enemyPos = new Vector3(startPosX + Random.Range(-rngRangeX, rngRangeX), newEnemy.transform.lossyScale.y/2f, Random.Range(minZ, maxZ));
           

            if(enemy.GetComponent<BasicEnemy>())
            {
                enemy.GetComponent<BasicEnemy>().ep =  Vector3.right * deathZ;
            }
            newEnemy.transform.position = enemyPos;
        }
    }
    public int getWaveNum()
    {
        return waveNum;
    }
    public static int getWave()
    {
        return instance.getWaveNum();
    }
    public void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (enemiesParent.transform.childCount <3)
        {
            StartWave();
        }
    }
    public GameObject[] concat(GameObject[] x , GameObject[] y)
    {
        var z = new GameObject[x.Length + y.Length];
        x.CopyTo(z, 0);
        y.CopyTo(z, x.Length);
        return z;
    }
}
