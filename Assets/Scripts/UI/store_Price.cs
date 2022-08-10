using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class store_Price : MonoBehaviour
{
    [SerializeField] private bool i_1 = false;
    [SerializeField] private bool i_2 = false;
    [SerializeField] private bool i_3 = false;
    [SerializeField] private TextMeshProUGUI text;
 


    void Update()
    {
        if(i_1){text.text = string.Format("{0000}", Buy.price_1);}
        else if(i_2){text.text = string.Format("{0000}", Buy.price_2);}
        else if(i_3){text.text = string.Format("{0000}", Buy.price_3);}
    }
}
