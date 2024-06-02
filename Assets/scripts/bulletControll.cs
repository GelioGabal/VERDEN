using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControll : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    public float speed = 300f;
    public int damage = 20;
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
        Debug.Log("Я вошел нахой");

        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            Debug.Log("Я вошел нахой");
            Attack attack = other.GetComponent<Attack>();
            attack.health -= damage;
            if (attack.health <= 0)
            {
                Destroy(other.gameObject);
            }
            Transform helthBar = other.transform.GetChild(0).gameObject.transform;
            helthBar.localScale = new Vector3(
                    helthBar.localScale.x - 0.2f,
                    helthBar.localScale.y,
                    helthBar.localScale.z);

        }

    }
}
