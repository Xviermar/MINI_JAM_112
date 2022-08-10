using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mag_Dam : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI text;

    void Update()
    {
        display();
    }


     private void display()
    {
     
        //Floor to int redondea el numero
        

        text.text = string.Format("{0000000}", player_Script.magic_Dam);
    }
}
