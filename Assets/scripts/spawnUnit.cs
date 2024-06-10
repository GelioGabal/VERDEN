using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnUnit : MonoBehaviour
{
    [NonSerialized]
    public bool isEnemy = false;
    public GameObject fly_1;
    public float timeSpawn = 1f;
    private void Start()
    {
        StartCoroutine(SpawnCar());
    }
    
    IEnumerator SpawnCar()
    {

        for (int i = 1; i <= 1000; i++)
        {
            yield return new WaitForSeconds(timeSpawn);
            Vector3 pos = new Vector3(
                transform.GetChild(0).position.x + 10f,
                transform.GetChild(0).position.y,
                transform.GetChild(0).position.z - 50f);
            //var rnd = new Unity.Mathematics.Random();
            //int randEnemy = rnd.NextInt(1,3);


            GameObject spawn = Instantiate(fly_1, transform.GetChild(1).position, Quaternion.identity);


            if (isEnemy)
            {
                spawn.tag = "Enemy";
            }
        }
        
    }
}
