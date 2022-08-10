using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class H : MonoBehaviour
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
        

        text.text = string.Format("{000000}", player_Health.current_Health);
    }
}
