using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class return_menu : MonoBehaviour
{
    public void returnTo()
    {
        SceneManager.LoadScene("Menu");
    }
}
