using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2dObject : MonoBehaviour
{
    public float seconds = 10f;

    void Update(){
        Destroy(gameObject, seconds);
    }
}
