using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    // SerializeField allows making private variable visible in
    //inspector without making it public
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // player's position will be set to respawn point
            player.transform.position = respawnPoint.transform.position;
           
            //apply trasnsform changes to physics engine
            Physics.SyncTransforms();

        }
    }

}
