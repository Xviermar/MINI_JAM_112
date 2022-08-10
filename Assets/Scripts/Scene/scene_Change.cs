using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_Change : MonoBehaviour
{
    public static int next_Lvl = 0;
    public static bool change = false;
    private player_Script player;


    private void Update() {
        if(change)
        {
            switch(next_Lvl)
            {
                case 0:
                    SceneManager.LoadScene("Funkiviathan");
                    change = false;
                    break;

                case 1:
                    SceneManager.LoadScene("Afrobub");
                    change = false;
                    break;

                case 2:
                    SceneManager.LoadScene("Demonny Benet");
                    change = false;
                    break;
            }
        }
    }
}
