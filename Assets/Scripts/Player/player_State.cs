using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_State : MonoBehaviour
{
    private player_Script player;
    private enemy_Script enemy;
    private Score score_S;
    private level_Scaling level;

    public static int score = 0;

    void Start()
    {
        player = gameObject.GetComponent<player_Script>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy_Script>();
        score_S = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        level = gameObject.GetComponent<level_Scaling>();
    }

    private void Update() {
        
        //Game Over
        if(player_Health.current_Health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("game_Over");
        }

        //Win
        if(enemy.health <= 0)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Death",true);
            enemy.can_Attack = false;

            StartCoroutine(enemy_Death());
            
            
        }
    }

    IEnumerator enemy_Death()
    {
        yield return new WaitForSeconds(2f);

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>().SetBool("Death",false);
        //Destroy(GameObject.FindGameObjectWithTag("Enemy"));

        score_S.add_Score(enemy.score);
        score += player_Health.current_Health;
        player_Health.current_Health += 60;
        level_Scaling.level += 6;
        scene_Change.next_Lvl += 1;
        enemy.can_Attack = true;
        
         if(scene_Change.next_Lvl >= 3)
        {
            scene_Change.next_Lvl = 0;
            Buy.price_1 += 150;
            Buy.price_2 += 150;
            Buy.price_3 += 150;
            enemy.score += 50;
            enemy.health += 80;
        }

        SceneManager.LoadScene("store");
        

            

       
    }

}
