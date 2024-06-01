using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public float radius = 70f;
    public int health = 100;
    public GameObject bullet;
    private Coroutine _Coroutine = null;
    private void Update()
    {
        DetectColision();
    }

    private void DetectColision()
    {
        Collider[] hitCollader = Physics.OverlapSphere(transform.position, radius);
        if (hitCollader.Length == 0 && _Coroutine != null)
        {
            StopCoroutine(_Coroutine);
            _Coroutine = null;
            if (CompareTag("Enemy"))
            {
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
            }
        }
        foreach (Collider col in hitCollader)
        {
            if ((gameObject.CompareTag("Player") && col.gameObject.CompareTag("Enemy")) ||
                (gameObject.CompareTag("Enemy") && col.gameObject.CompareTag("Player")))
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    GetComponent<NavMeshAgent>().SetDestination(col.transform.position);
                }
                if (_Coroutine == null)
                {
                    _Coroutine = StartCoroutine(StartAttack(col));
                }


            }
        }
        IEnumerator StartAttack(Collider enemyPos)
        {

            GameObject objectsukably = Instantiate(bullet, transform.GetChild(1).position, Quaternion.identity);
            objectsukably.GetComponent<bulletControll>().position = enemyPos.transform.position;
            yield return new WaitForSeconds(1f);
            StopCoroutine(_Coroutine);
            _Coroutine = null;
        }
    }
}


