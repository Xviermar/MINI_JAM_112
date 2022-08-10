using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void start_Game()
    {
        SceneManager.LoadScene("Funkiviathan");
        player_Health.max_Health = 175;
        player_Health.current_Health = player_Health.max_Health;
        level_Scaling.level = 1;
    }

    public void quit_Game()

    {
        Application.Quit();
    }

    public void main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
        scene_Change.next_Lvl = 0;
        player_Health.max_Health = 175;
        player_Health.current_Health = player_Health.max_Health;
        player_Script.defence = 10;
        player_Script.melee_Dam = 25;
        player_Script.magic_Dam = 45;
        player_State.score = 0;
        level_Scaling.level = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene("Funkiviathan");
        scene_Change.next_Lvl = 0;
        player_Health.max_Health = 175;
        player_Health.current_Health = player_Health.max_Health;
        player_Script.defence = 10;
        player_Script.melee_Dam = 25;
        player_Script.magic_Dam = 45;
        level_Scaling.level = 1;
    }
}
