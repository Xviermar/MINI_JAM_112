using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private GameObject item_1;
    [SerializeField] private GameObject item_2;
    [SerializeField] private GameObject item_3;

    void Update()
    {
        buy();
    }

    private void buy()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(player_State.score >= 50)
            {
                Destroy(item_1);
                player_State.score -= 50;
            }
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(player_State.score >= 100)
            {
                Destroy(item_2);
                player_State.score -= 100;
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(player_State.score >= 150)
            {
                Destroy(item_3);
                player_State.score -= 150;
            }
        }
    }
}
