using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Defence : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display();
    }


     private void display()
    {
     
        //Floor to int redondea el numero
        

        text.text = string.Format("{0000000}", player_Script.defence);
    }
}
