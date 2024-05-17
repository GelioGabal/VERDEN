using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float RotateSpeed = 10.0f, moveSpeed = 100f, zoomSpeed = 30f, sensitivity = 0f;
    public float Boost = 1f;
    private Vector3 lastMouse = new Vector3(255, 255, 255), direction = Vector3.zero;

    private void Update()
    {
        WASDMove();
        zoomMove();
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -150f, 1140f),
            Mathf.Clamp(transform.position.y, 9f, 160f),
            Mathf.Clamp(transform.position.z, -65f, 800f));
    }
    public void WASDMove()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * Boost * moveSpeed, Space.Self);


    }
    public void zoomMove()
    {

        transform.position += transform.up * zoomSpeed * -1 * Input.GetAxis("Mouse ScrollWheel");

        
    }
}
