using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuild : MonoBehaviour
{
    public GameObject bulder;
    public float height = 0;
    public void PlaceObject()
    {
        Instantiate(bulder, Vector3.zero, Quaternion.Euler(-90, 0, 0));
        bulder.transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
    }
}
