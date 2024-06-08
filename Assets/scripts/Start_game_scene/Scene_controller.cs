using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Start_game()
    {
        SceneManager.LoadScene("Terrain");
    }
    // Update is called once per frame
    public void Settings()
    {
        
    }

    public void Exit()
    {
        Debug.Log("Игра Закончилась идите нахуй");
        Application.Quit();
    }
}
