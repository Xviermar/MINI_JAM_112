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
    public GameObject blood_Splash;
    
    private player_Script player;
    private timer timer;
    private bool start = false;
    private int random;
    private Slider slider;
    private Animator anim;
    
    [SerializeField] private int defence;
    [SerializeField] private int damage;
    [SerializeField] private int mag_Damage;
    [SerializeField] private GameObject block_A;
    

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Script>();
        slider = GameObject.FindGameObjectWithTag("E Health Bar").GetComponent<Slider>();
        anim = gameObject.GetComponent<Animator>();
        
        mag_Damage = mag_Damage + level_Scaling.level;
        damage = damage + level_Scaling.level;
        defence = defence + level_Scaling.level;

        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {
       attack(timer.timer_Time); 
    }

    private void attack(float time)
    {
        
        
        if(anim.GetBool("Attack"))
        {
            StartCoroutine(anim_Timer());
        }
        
        if(start == false)
        {
            StartCoroutine(wait_1(1f));
        }

        random = Random.Range(1,10);
        if(can_Attack && start)
        {
            
            switch(random){
                case int n when(n >= 1 && n <= 4) && block == false:
                    
                    anim.SetBool("Attack", true);
                    
                    can_Attack = false;
                    
                    StartCoroutine(dam(damage));
                    StartCoroutine(wait(2.5f));
                    break;

                case int n when(n >= 7 && n <= 9):
                    can_Attack = false;
                    block = true;
                    block_A.SetActive(true);
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n == 5 || n == 10) && block == false:
                    anim.SetBool("Attack", true);
                    
                    can_Attack = false;

                    StartCoroutine(dam(mag_Damage));
                    StartCoroutine(wait(4.5f));
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
        block_A.SetActive(false);
    }

    IEnumerator wait_1(float e)
    {
        yield return new WaitForSeconds(e);
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
        GameObject g = Instantiate(blood_Splash, player.transform.position, Quaternion.identity);
        g.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
        player.take_Damage(damage);
    }
}
