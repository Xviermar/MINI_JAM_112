using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class store_Timer : MonoBehaviour
{
    [SerializeField] private float timer_Time = 5;
    [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
        if(timer_Time > 0)
        {
            timer_Time -= Time.deltaTime;
        }else
        {
            SceneManager.LoadScene("Funkiviathan");
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

}
