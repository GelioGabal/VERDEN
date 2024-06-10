using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    public float radius = 70f;
    public int health = 100;
    public GameObject bullet;
    public GameObject point;
    private Coroutine _Coroutine = null;
    private Animator animator;
    public bool is_dot;
    private void Update()
    {
        
        DetectCollision();
        if (CompareTag("Enemy") && !is_dot)
        {
            GetComponent<NavMeshAgent>().SetDestination(point.transform.position);
        }
    }

    private void DetectCollision()
    {
        Collider[] hitCollader = Physics.OverlapSphere(transform.position, radius);
        if (hitCollader.Length == 0 && _Coroutine != null)
        {
            StopCoroutine(_Coroutine);
            _Coroutine = null;
            if (CompareTag("Enemy") && !is_dot)
            {
                GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
            }
        }
        foreach (Collider col in hitCollader)
        {
            if ((gameObject.CompareTag("Player") && col.gameObject.CompareTag("Enemy")) ||
                (gameObject.CompareTag("Enemy") && col.gameObject.CompareTag("Player")))
            {
                if (gameObject.CompareTag("Enemy") && !is_dot)
                {
                    GetComponent<NavMeshAgent>().SetDestination(col.transform.position);
                }

                if (_Coroutine == null)
                {
                    
                    _Coroutine = StartCoroutine(StartAttack(col));
                    if (!is_dot)
                    {
                        //переход в состояние стрельбы и обратно
                        animator = GetComponent<Animator>();
                        animator.SetInteger("Shoot", 1);
                        animator.SetInteger("Run", 0);
                    }
                }

                if (_Coroutine != null && !is_dot)
                {
                 animator.SetInteger("Shoot", 0); 
                }

                }
        }
        IEnumerator StartAttack(Collider enemyPos)
        {

            // Debug.Log("Я вошел нахой");

            GameObject objectsukably = Instantiate(bullet, transform.GetChild(1).position, Quaternion.Euler(0, 0, -90));
            objectsukably.GetComponent<bulletControll>().position = enemyPos.transform.position;
            yield return new WaitForSeconds(1f);
            StopCoroutine(_Coroutine);
            _Coroutine = null;
        }
    }
}


