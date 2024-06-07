using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Animator animator;
    SelectController controller = new SelectController();
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && controller.Units.Count > 0)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, controller.mask))
            {
                foreach (var el in controller.Units)
                {
                    el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                    //так *****, здесь же должно работать, не?
                    /*animator = GetComponent<Animator>();
                    animator.SetInteger("Shoot", 0);
                    animator.SetInteger("Run", 1);

                    else { animator.SetInteger("Run", 1); }*/
                }
                
            }
        }
    }

}
