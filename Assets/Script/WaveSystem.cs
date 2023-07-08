using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemiesParent;
    [SerializeField] private TMP_Text waveText;

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
            GameObject newEnemy = Instantiate(enemy, enemiesParent);
            Vector3 enemyPos = new Vector3(startPosX, 1.5f, Random.Range(minZ, maxZ));
           
            newEnemy.transform.position = enemyPos;
            newEnemy.transform.Rotate(45, 0, 0);
        }
    }

    private void Update()
    {
        if (enemiesParent.transform.childCount == 0)
        {
            StartWave();
        }
    }
}
