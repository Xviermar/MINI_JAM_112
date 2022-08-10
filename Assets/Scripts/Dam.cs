using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dam : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
        display();
    }


     private void display()
    {
     
        //Floor to int redondea el numero
        

        text.text = string.Format("{000000}", player_Script.melee_Dam);
    }
}
