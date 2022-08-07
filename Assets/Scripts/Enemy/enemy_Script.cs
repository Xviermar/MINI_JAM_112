using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class enemy_Script : MonoBehaviour
{
    private GameObject player;
    private timer timer;
    private bool can_Attack = false;
    private bool start = false;
    private int random;
    [SerializeField] private int health = 100;
    [SerializeField] private int defence = 15;
    [SerializeField] private int damage = 15;

    

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<timer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       attack(timer.timer_Time); 
    }

    private void attack(float time)
    {

        if(start == false)
        {
            StartCoroutine(wait(1f));
            random = Random.Range(1,10);
        }

        if(can_Attack)
        {
            switch(random){
                case int n when(n >= 1 && n <= 3):
                    can_Attack = false;
                    random = Random.Range(1,10);
                    Debug.Log("Attack_E");
                    StartCoroutine(wait(2f));
                    break;

                case int n when(n >= 6 && n <= 8f):
                    can_Attack = false;
                    random = Random.Range(1,10);
                    Debug.Log("Block_E");
                    StartCoroutine(wait(2f));
                    break;
            }
        }
        
    }

    IEnumerator wait(float i)
    {
        yield return new WaitForSeconds(i);
        can_Attack = true;
        start = true;
    }
}
