using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    [SerializeField] GameObject obj;

    void Start()
    {
        if(obj){
            obj.SetActive(false);
        }
    }

}
