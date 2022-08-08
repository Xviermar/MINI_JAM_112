using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    public bool block = false;
    public int health = 100;
    public int score;
    
    private player_Script player;
    private timer timer;
    private bool can_Attack = true;
    private bool start = false;
    private int random;
    private Slider slider;
    
    [SerializeField] private int defence = 5 + level_Scaling.level;
    [SerializeField] private int damage = 15 + level_Scaling.level;
    [SerializeField] private int mag_Damage = 35 + level_Scaling.level;

    

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Script>();
        slider = GameObject.FindGameObjectWithTag("E Health Bar").GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
       attack(timer.timer_Time); 
    }

    private void attack(float time)
    {
        random = Random.Range(1,10);
        if(start == false)
        {
            StartCoroutine(wait_1());
        }

        if(can_Attack && start)
        {
            switch(random){
                case int n when(n >= 1 && n <= 4):
                    player.take_Damage(damage);
                    
                    can_Attack = false;
                    Debug.Log("Attack_E");
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n >= 6 && n <= 9f):
                    can_Attack = false;
                    block = true;
                    Debug.Log("Block_E");
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n == 5 || n == 10):
                    player.take_Damage(mag_Damage);
                    
                    can_Attack = false;
                    Debug.Log("Magic_E");
                    StartCoroutine(wait(4f));
                    break;
            }
        }
        
    }

    public void take_Damage(int damage)
    {
        if(block)
        {
            health -= (damage - defence);
            slider.value = health;
        }
        else
        {
            health -= (damage);
            slider.value = health;    
        }
    }

    IEnumerator wait(float i)
    {
        yield return new WaitForSeconds(i);
        can_Attack = true;
        block = false;
    }

    IEnumerator wait_1()
    {
        yield return new WaitForSeconds(1f);
        start = true;
    }
}
