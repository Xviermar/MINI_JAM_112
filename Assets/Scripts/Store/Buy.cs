using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private GameObject item_1;
    [SerializeField] private GameObject item_2;
    [SerializeField] private GameObject item_3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buy();
    }

    private void buy()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Destroy(item_1);
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Destroy(item_2);
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(item_3);
        }
    }
}
