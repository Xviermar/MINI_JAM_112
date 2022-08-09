using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_Selector : MonoBehaviour
{
    public List<GameObject> objects_To_Spawn;
    void Start()
    {
        int random = Random.Range(0,4);
        gameObject.GetComponent<SpriteRenderer>().sprite = objects_To_Spawn[random].GetComponent<SpriteRenderer>().sprite;
        gameObject.name = objects_To_Spawn[random].name;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
