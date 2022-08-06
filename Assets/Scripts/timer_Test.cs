using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer_Test : MonoBehaviour
{
    [SerializeField] private float timer_Time = 25f;
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField] private GameObject player;
    private float force = .5f;

    void Update()
    {
        if(timer_Time > 0)
        {
            timer_Time -= Time.deltaTime;
            
            move(timer_Time, player);
        }else
        {
            reset_Timer(25f);
        }

        display(timer_Time);
    }

    private void display(float time)
    {
        if(time < 0)
        {
            time = 0;
        }
        else if(time > 0)
        {
            time += 1;
        }
        
        //Floor to int redondea el numero
        float min = Mathf.FloorToInt(time / 60);
        float seg = Mathf.FloorToInt(time % 60);

        text.text = string.Format("{00:00}:{01:00}", min, seg);
    }

    private void reset_Timer(float time)
    {
        timer_Time += time;
    }

    private void move(float time, GameObject p)
    {
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            switch(time){
                case float n when(n >= 20f && n <= 25):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.up * force);
                    Debug.Log("UP");
                    break;
                
                case float n when(n >= 15f && n <= 19.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (force * .3f));
                    Debug.Log("UP");
                    break;

                case float n when(n >= 10f && n <= 14.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (force * .45f));
                    Debug.Log("UP");
                    break;
                    
                case float n when(n >=5f && n <= 9.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (force * .55f));
                    Debug.Log("UP");
                    break;

                case float n when(n >=0f && n <= 4.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (force * .65f));
                    Debug.Log("UP");
                    break;
            }
        }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                switch(time){
                case float n when(n >= 20f && n <= 25):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.down * force);
                    Debug.Log("DOWN");
                    break;
                
                case float n when(n >= 15f && n <= 19.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.down * (force * .3f));
                    Debug.Log("DOWN");
                    break;

                case float n when(n >= 10f && n <= 14.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.down * (force * .45f));
                    Debug.Log("DOWN");
                    break;
                    
                case float n when(n >=5f && n <= 9.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.down * (force * .55f));
                    Debug.Log("DOWN");
                    break;

                case float n when(n >=0f && n <= 4.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.down * (force * .65f));
                    Debug.Log("DOWN");
                    break;
            }
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            switch(time){
                case float n when(n >= 20f && n <= 25):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.left * force);
                    Debug.Log("LEFT");
                    break;
                
                case float n when(n >= 15f && n <= 19.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.left * (force * .3f));
                    Debug.Log("LEFT");
                    break;

                case float n when(n >= 10f && n <= 14.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.left * (force * .45f));
                    Debug.Log("LEFT");
                    break;
                    
                case float n when(n >=5f && n <= 9.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.left * (force * .55f));
                    Debug.Log("LEFT");
                    break;

                case float n when(n >=0f && n <= 4.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.left * (force * .65f));
                    Debug.Log("LEFT");
                    break;
            }
        }

         else if(Input.GetKey(KeyCode.RightArrow))
        {
            switch(time){
                case float n when(n >= 20f && n <= 25):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.right * force);
                    Debug.Log("RIGHT");
                    break;
                
                case float n when(n >= 15f && n <= 19.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.right * (force * .3f));
                    Debug.Log("RIGHT");
                    break;

                case float n when(n >= 10f && n <= 14.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.right * (force * .45f));
                    Debug.Log("RIGHT");
                    break;
                    
                case float n when(n >=5f && n <= 9.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.right * (force * .55f));
                    Debug.Log("RIGHT");
                    break;

                case float n when(n >=0f && n <= 4.9f):
                    p.GetComponent<Rigidbody2D>().AddForce(Vector3.right * (force * .65f));
                    Debug.Log("RIGHT");
                    break;
            }
        }
    }
}
