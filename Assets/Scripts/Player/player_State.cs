using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_State : MonoBehaviour
{
    private player_Script player;
    private enemy_Script enemy;

    void Start()
    {
        player = gameObject.GetComponent<player_Script>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy_Script>();
    }

    private void Update() {
        
        //Game Over
        if(player.health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("game_Over");
            
        }

        //Win
        if(enemy.health <= 0)
        {
            SceneManager.LoadScene("store");
        }
    }

}
