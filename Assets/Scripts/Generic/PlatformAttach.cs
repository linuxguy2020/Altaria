using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        // if the colliding game object is the player,
        // set the parent of the players transform to the
        // platform.
        // So the platform is now the parent of the player,
        // this means if the platform is moving, the player
        // will move as well

        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        // here set parent of players transform to null, this
        // means we are removing the parent
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
        }  
  }
}
