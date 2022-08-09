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
                if(item_1.name == "Holy Water")
                {
                    player_Health.current_Health += 75;
                }
                else if(item_1.name == "Beatrix Chastity")
                {
                    player_Script.defence += 5;
                }
                else if(item_1.name == "Vergil Favour")
                {
                    player_Script.ramp += .2f;
                }
                else if(item_1.name == "Acid In Chains")
                {
                    player_Script.defence -= 5;
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                else if(item_1.name == "Holy Vodka")
                {
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                
                Destroy(item_1);
                player_State.score -= 50;
            }
        }

        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(player_State.score >= 100)
            {
                 if(item_2.name == "Holy Water")
                {
                    player_Health.current_Health += 75;
                }
                else if(item_2.name == "Beatrix Chastity")
                {
                    player_Script.defence += 5;
                }
                else if(item_2.name == "Vergil Favour")
                {
                    player_Script.ramp += .2f;
                }
                else if(item_2.name == "Acid In Chains")
                {
                    player_Script.defence -= 5;
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                else if(item_2.name == "Holy Vodka")
                {
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                
                Destroy(item_2);
                player_State.score -= 100;
            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(player_State.score >= 150)
            {
                 if(item_3.name == "Holy Water")
                {
                    player_Health.current_Health += 75;
                }
                else if(item_3.name == "Beatrix Chastity")
                {
                    player_Script.defence += 5;
                }
                else if(item_3.name == "Vergil Favour")
                {
                    player_Script.ramp += .2f;
                }
                else if(item_3.name == "Acid In Chains")
                {
                    player_Script.defence -= 5;
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                else if(item_3.name == "Holy Vodka")
                {
                    player_Script.magic_Dam += 5;
                    player_Script.melee_Dam += 5;
                }
                
                Destroy(item_3);
                player_State.score -= 150;
            }
        }
    }
}
