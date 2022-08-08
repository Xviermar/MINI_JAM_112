using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void start_Game()
    {
        SceneManager.LoadScene("Funkiviathan");
    }

    public void quit_Game()

    {
        Application.Quit();
    }

    public void main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
