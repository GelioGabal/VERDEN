using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControll : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 30f;
    public int damage = 20;
    public GameObject defeatBuild;
    private bool victory=false, defeat=false;
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        if (transform.position == position)
        {
            Destroy(gameObject);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Attack attack = other.GetComponent<Attack>();
            attack.health -= damage;
            if (attack.health <= 0 && defeatBuild.CompareTag("Player"))
            {
                victory = true;
            }
            if (attack.health <= 0)
            {
                Destroy(other.gameObject);
                Debug.Log(victory);
            }
            Transform helthBar = other.transform.GetChild(0).gameObject.transform;
            helthBar.localScale = new Vector3(
                    helthBar.localScale.x,
                    helthBar.localScale.y,
                    helthBar.localScale.z - 0.2f);

        }

    }
}
