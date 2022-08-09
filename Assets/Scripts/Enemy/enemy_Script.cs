using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    public bool block = false;
    public int health = 100;
    public int score;
    public bool can_Attack = true;
    
    private player_Script player;
    private timer timer;
    private bool start = false;
    private int random;
    private Slider slider;
    private Animator anim;
    
    [SerializeField] private int defence = 5 + level_Scaling.level;
    [SerializeField] private int damage = 15 + level_Scaling.level;
    [SerializeField] private int mag_Damage = 35 + level_Scaling.level;

    

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Script>();
        slider = GameObject.FindGameObjectWithTag("E Health Bar").GetComponent<Slider>();
        anim = gameObject.GetComponent<Animator>();
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
        
        if(anim.GetBool("Attack"))
        {
            StartCoroutine(anim_Timer());
        }
        
        if(start == false)
        {
            StartCoroutine(wait_1());
        }

        if(can_Attack && start)
        {
            switch(random){
                case int n when(n >= 1 && n <= 4):
                    anim.SetBool("Attack", true);
                    
                    
                    can_Attack = false;
                    Debug.Log("Attack_E");
                    StartCoroutine(dam(damage));
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n >= 6 && n <= 9f):
                    can_Attack = false;
                    block = true;
                    Debug.Log("Block_E");
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n == 5 || n == 10):
                    anim.SetBool("Attack", true);
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

    IEnumerator anim_Timer()
    {
        yield return new WaitForSeconds(.7f);   
        
        anim.SetBool("Attack", false);
          
    }

    IEnumerator dam(int damage)
    {
        yield return new WaitForSeconds(1f);
        player.take_Damage(damage);
    }
}
