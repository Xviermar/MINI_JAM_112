using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private player_State player;

    private void Update() {
        display();
    }

    private void display()
    {

        text.text = string.Format("{0000}", player_State.score);
    }

    public void add_Score(int score)
    {
        player_State.score += score;
    }
}
