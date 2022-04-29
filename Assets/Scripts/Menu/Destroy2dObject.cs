using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2dObject : MonoBehaviour
{
    //The whole animations of the menu revolves around the fades of the textures 
    //of the 2D objects that compose it. Being rendered in order, some objects 
    //end up on top of the buttons. To prevent them from becoming inaccessible, 
    //they are destroyed after a certain time using this script

    public float seconds = 10f;

    void Update(){
        Destroy(gameObject, seconds);
    }
}
