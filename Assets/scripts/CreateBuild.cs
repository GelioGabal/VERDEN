using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuild : MonoBehaviour
{
    public GameObject bulder;
    public float height = 10;
    public void PlaceObject()
    {
        Instantiate(bulder, Vector3.zero, Quaternion.identity);
        bulder.transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
    }
}
