using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_Script : MonoBehaviour
{
    public bool can_block = true;
    //public static int health = 175;

    private enemy_Script enemy;
    public static int defence = 10;
    public static int melee_Dam = 25;
    public static int magic_Dam = 45;
    public static float ramp = 1.2f;
    private bool can_Attack = true;
    private Slider slider;
    private Animator anim;

    [SerializeField] private timer timer;
    [SerializeField] private GameObject melee_Icon;
    [SerializeField] private GameObject magic_Icon;
    [SerializeField] private GameObject block_Icon;
    
    
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();   
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy_Script>();
        slider = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Slider>();
        anim = gameObject.GetComponent<Animator>();
        slider.maxValue = player_Health.max_Health;
        slider.value = player_Health.current_Health;
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
        
        //Melee
        if(Input.GetKeyDown(KeyCode.UpArrow) && can_Attack && can_block)
        {
            if(Mathf.RoundToInt(time) % 2 == 0)
            {
                anim.SetBool("Attack", true);
                melee_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                can_Attack = false;
                StartCoroutine(dam(melee_Dam, false));
                

                StartCoroutine(attack_Timer(2f));
                
            }
        }

        //Melee Rampage
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            if(Input.GetKey(KeyCode.RightArrow) && can_Attack && can_block)
            {
                if(Mathf.RoundToInt(time) % 2 == 0)
                {
                    anim.SetBool("Attack", true);
                    melee_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                    StartCoroutine(dam(melee_Dam, true));

                    can_Attack = false;
                    StartCoroutine(attack_Timer(4.5f));
                }
            }
        }

        //Magic
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && can_Attack && can_block)
        {
            switch(time){
                case float n when(n >= 3.8f && n <= 5.2f):
                    
                    anim.SetBool("Attack", true);
                    magic_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                    StartCoroutine(dam(magic_Dam, false));
                    
                    can_Attack = false;
                    StartCoroutine(attack_Timer(3.5f));
                    break;

                case float n when(n >= 8.8f && n <= 10f):
                    anim.SetBool("Attack", true);
                    magic_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                    StartCoroutine(dam(magic_Dam, false));
                    
                    can_Attack = false;
                    StartCoroutine(attack_Timer(3.5f));
                    break;
            }
        }

        //Magic Rampage
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(Input.GetKey(KeyCode.RightArrow) && can_Attack && can_block)
            {
                switch(time){
                case float n when(n >= 3.8f && n <= 5.2f):
                    anim.SetBool("Attack", true);
                    magic_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                    StartCoroutine(dam(magic_Dam, true));

                    can_Attack = false;
                    StartCoroutine(attack_Timer(5.5f));
                    break;

                case float n when(n >= 8.8f && n <= 10f):
                    anim.SetBool("Attack", true);
                    magic_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
                    StartCoroutine(dam(magic_Dam, true));

                    can_Attack = false;
                    StartCoroutine(attack_Timer(5.5f));
                    break;
                }
            }
        }

        //Dodge hacer el dodge cargado cuando haya enemigo pra testear
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
          
            
            can_block = false;
            can_Attack = false;
            block_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0.25f);
            Debug.Log("Block");
            StartCoroutine(block_Timer(2f));
            
        }
    }

    public void take_Damage(int damage)
    {
        if(can_block == false)
        {
            player_Health.current_Health -= (damage - defence);
            slider.value = player_Health.current_Health;
        }
        
        else
        {
            player_Health.current_Health -= damage;
            slider.value = player_Health.current_Health;    
        }
    }

    IEnumerator block_Timer(float i)
    {
        yield return new WaitForSeconds(i);
        block_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        can_block = true;
        can_Attack = true;
    }
    
    //Decide cuanto tiempo para poder atacar
    IEnumerator attack_Timer(float i)
    {
        yield return new WaitForSeconds(i);
        melee_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1f);
        magic_Icon.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1f);
        can_Attack = true;
    }

    IEnumerator anim_Timer()
    {
        yield return new WaitForSeconds(.8f);   
        
        anim.SetBool("Attack", false);
    }

    IEnumerator dam(int damage, bool rampage)
    {
        yield return new WaitForSeconds(.8f);
        if(rampage)
        {
            enemy.take_Damage(damage * Mathf.RoundToInt(ramp));
        }else
        {
            enemy.take_Damage(damage);
        }
    }

}

