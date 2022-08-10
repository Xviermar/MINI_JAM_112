using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    void Update()
    {
        Destroy(this.gameObject, 0.35f);
    }
}
