using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame_Cap : MonoBehaviour
{
    [SerializeField] private int cap = 60;
    private void Awake() {
        Application.targetFrameRate = cap;
    }
}
