using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float timer_Time = 10;
    [SerializeField]private TextMeshProUGUI text;

    void Update()
    {
        if(timer_Time > 0)
        {
            timer_Time -= Time.deltaTime;
        }else
        {
            reset_Timer(10);
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
        float seg = Mathf.FloorToInt(time % 60);

        text.text = string.Format("{00}", seg);
    }

    private void reset_Timer(float time)
    {
        timer_Time += time;
    }
}
