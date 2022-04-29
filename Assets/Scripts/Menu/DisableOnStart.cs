using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour
{

    //disable the 2d object to which the script is assigned at scene start. 
    //The script is useful for deactivating submenus when starting the game

    [SerializeField] GameObject obj;

    void Start()
    {
        if(obj){
            obj.SetActive(false);
        }
    }

}
