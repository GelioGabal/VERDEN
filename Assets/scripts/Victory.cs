using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameObject MainBuildPlayer = null;
    public GameObject VictoryAlert;

    private void Update()
    {
        MainBuildPlayer = GameObject.Find("glav_zdanie");
        if (MainBuildPlayer == null)
        {
            Time.timeScale = 0f;
            VictoryAlert.SetActive(true);
            Debug.Log("Main_player");
        }
    }
}
