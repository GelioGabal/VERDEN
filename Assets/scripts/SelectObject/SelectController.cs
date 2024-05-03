using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
    public GameObject selectZone;
    private GameObject select;
    public LayerMask mask, BuldMask,UnitMask;
    private Camera _cam;
    public GameObject Build;
    private RaycastHit hit;
    public List<GameObject> Units;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {


        CreateSelectZone();
    }

    private void CreateSelectZone()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var el in Units)
            {
                if (el != null)
                    el.transform.GetChild(0).gameObject.SetActive(false);
            }
            Units.Clear();
            Ray ray=_cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit,1000f, mask) ) 
            {
               select= Instantiate(selectZone, new Vector3(hit.point.x, 1, hit.point.z),Quaternion.identity);
            }
        }
        if (select)
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hitDrag;
            if (Physics.Raycast(ray, out _hitDrag, 1000f, mask))
            {
                float xScale = (hit.point.x - _hitDrag.point.x) * -1;
                float zScale = (hit.point.z - _hitDrag.point.z);
                if (xScale < 0.0f && zScale < 0.0f)
                {
                    select.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                else if (zScale < 0.0f)
                {
                    select.transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
                }
                else if (xScale < 0.0f)
                {
                    select.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                }
                else
                {
                    select.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                select.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, Mathf.Abs(zScale));

            }
        }
        if (Input.GetMouseButtonUp(0) && select)
        {
            RaycastHit[] hits = Physics.BoxCastAll(
                 select.transform.position,
                 select.transform.localScale,
                 Vector3.up, Quaternion.identity, 0, UnitMask);
            foreach (var el in hits)
            {
                if (el.collider.CompareTag("Enemy"))
                {
                    continue;
                }
                Units.Add(el.transform.gameObject);
                el.transform.GetChild(0).gameObject.SetActive(true);

            }
            Destroy(select);
        }
    }

}
