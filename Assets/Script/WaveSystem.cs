using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private TMP_Text waveText;
    public float deathZ = 0;
    public float rngRangeX = 10;
    [SerializeField] private int startPosX;
    [SerializeField] private int minZ;
    [SerializeField] private int maxZ;


    //[SerializeField] private int enemiesAlive;
    [SerializeField] private int slope;


    [SerializeField] private int waveNum = 0;

    void StartWave()
    {
        waveNum++;
        waveText.text = "Wave " + waveNum;
        for(int i = 0; i < waveNum * slope; i++)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            GameObject newEnemy = Instantiate(enemy, enemiesParent);
            Vector3 enemyPos = new Vector3(startPosX + Random.Range(-rngRangeX, rngRangeX), 1.5f, Random.Range(minZ, maxZ));
           

            if(enemy.GetComponent<BasicEnemy>())
            {
                enemy.GetComponent<BasicEnemy>().ep = enemy.GetComponent<BasicEnemy>().ep + Vector3.right * deathZ;
            }
            newEnemy.transform.position = enemyPos;
        }
    }

    private void Update()
    {
        if (enemiesParent.transform.childCount == 0)
        {
            Debug.Log("WAVEE");
            StartWave();
        }
    }
}
