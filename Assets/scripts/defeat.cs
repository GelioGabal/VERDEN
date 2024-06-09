using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeat : MonoBehaviour
{
    private GameObject MainBuildPlayer=null ;
    public  GameObject defeatedAlert;

    private void Update()
    {
        MainBuildPlayer = GameObject.Find("Main_player");
        if (MainBuildPlayer == null)
        {
            Time.timeScale = 0f;
            defeatedAlert.SetActive(true);
            Debug.Log("Main_player");
        }
    }
}
