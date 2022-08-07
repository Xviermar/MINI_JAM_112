using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Script : MonoBehaviour
{

    [SerializeField] private timer timer;
    private int health = 100;
    private int defence = 80;
    private int danage = 50;
    private bool can_Attack = true;

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();   
    }

    void Update()
    {
        attack(timer.timer_Time);   
    }

    private void attack(float time)
    {
        //Melee
        if(Input.GetKeyDown(KeyCode.UpArrow) && can_Attack)
        {
            if(Mathf.RoundToInt(time) % 2 == 0)
            {
                can_Attack = false;
                Debug.Log("Melee");
                StartCoroutine(attack_Timer(2f));
            }
        }
        //Melee Rampage
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            if(Input.GetKey(KeyCode.RightArrow) && can_Attack)
            {
                if(Mathf.RoundToInt(time) % 2 == 0)
                {
                    can_Attack = false;
                    Debug.Log("Melee Rampage");
                    StartCoroutine(attack_Timer(4f));
                }
            }
        }

        //Magic
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && can_Attack)
        {
            switch(time){
                case float n when(n >= 3.8f && n <= 5.2f):
                    can_Attack = false;
                    Debug.Log("Magic");
                    StartCoroutine(attack_Timer(2f));
                    break;

                case float n when(n >= 8.8f && n <= 10f):
                    can_Attack = false;
                    Debug.Log("Magic");
                    StartCoroutine(attack_Timer(2f));
                    break;
            }
        }

        //Magic Rampage
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(Input.GetKey(KeyCode.RightArrow) && can_Attack)
            {
                switch(time){
                case float n when(n >= 3.8f && n <= 5.2f):
                    can_Attack = false;
                    Debug.Log("Magic Rampage");
                    StartCoroutine(attack_Timer(4f));
                    break;

                case float n when(n >= 8.8f && n <= 10f):
                    can_Attack = false;
                    Debug.Log("Magic Rampage");
                    StartCoroutine(attack_Timer(4f));
                    break;
                }
            }
        }

        //Dodge hacer el dodge cargado cuando haya enemigo pra testear
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(Mathf.RoundToInt(time) % 2 != 0)
            {
                Debug.Log("Dodge");
            }
        }
    }

    //Decide cuanto tiempo para poder atacar
    IEnumerator attack_Timer(float i)
    {
        yield return new WaitForSeconds(i);
        can_Attack = true;
    }
}

