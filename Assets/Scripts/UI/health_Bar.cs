using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_Bar : MonoBehaviour
{
    private Transform bar;
    void Start()
    {
        bar = transform.Find("Health Bar");  
    }

    public void set_Health(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
