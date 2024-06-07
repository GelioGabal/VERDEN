using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public float time_m = 0;
    public TextMeshProUGUI valueMin;
    public TextMeshProUGUI valueSec;

    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 59.9)
        {
            time -= 60;
            time_m = time_m +1;
        }
        valueMin.text = time_m.ToString("0");
        valueSec.text = time.ToString("0");
        //10 мин = 600 сек
        //if (time > 600)
        if (time >90)
        {
            SceneManager.LoadScene("Loose");
        }
    }
}
