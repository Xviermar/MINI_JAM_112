using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_Selector : MonoBehaviour
{
    public List<Sprite> objects_To_Spawn;
    void Start()
    {
        int random = Random.Range(0,6);
        gameObject.GetComponent<Image>().sprite = objects_To_Spawn[random];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
