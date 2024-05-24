using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlaceObject : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 100f;
    private void Update()
    {
        PlaceObjects();
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y +2, transform.position.z);
            Destroy(gameObject.GetComponent<PlaceObject>());

        }
/*        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3. * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        }*/
    }
    public void PlaceObjects()
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100000f, layer))
        {
            transform.position = hit.point;
            

        }
    }
}
