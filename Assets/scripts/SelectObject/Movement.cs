using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
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
                }
            }
        }
    }
}
