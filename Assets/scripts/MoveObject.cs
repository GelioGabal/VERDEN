using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 100f;
    private void Start()
    {

        PlaceObject();
    }
    public void PlaceObject()
    {
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000f, layer))
        {
            transform.position = hit.point;
        }
    }
    private void Update()
    {
        PlaceObject();
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            Destroy(gameObject.GetComponent<MoveObject>());

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        }
    }
}
