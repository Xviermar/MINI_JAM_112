using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Script : MonoBehaviour
{

    [SerializeField] private timer timer;
    private int health = 100;
    private int defence = 80;
    private int danage = 50;

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
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(Mathf.RoundToInt(time) % 2 == 0)
            {
                Debug.Log("Melee");
            }
        }

        //Magic
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch(time){
                case float n when(n >= 4.8f && n <= 5.2f):
                    Debug.Log("Magic");
                    break;
                case float n when(n >= 8.8f && n <= 10f):
                    Debug.Log("Magic");
                    break;

            }
        }

        //Dodge
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(Mathf.RoundToInt(time) % 2 != 0)
            {
                Debug.Log("Dodge");
            }
        }
    }
}

