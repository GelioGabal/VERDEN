using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuild : MonoBehaviour
{
    public GameObject bulder;
    public GameObject massage;
    public float height = 0;
    [SerializeField] public int Max_col = 5;
    [SerializeField] public int col = 0;

    public void PlaceObject()
    {
        if (col <= Max_col)
        {
            Instantiate(bulder, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            col +=1;
        }
        else
        {
            massage.SetActive(true);
        }
        bulder.transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        Debug.Log(col);
    }
}
