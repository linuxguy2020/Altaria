using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField] private GameObject DeathMeshToActivate;
    [SerializeField] private GameObject DeathMeshToDeActivate1;
    [SerializeField] private GameObject DeathMeshToDeActivate2;
    [SerializeField] private GameObject DeathMeshToDeActivate3;

    private void OnTriggerEnter(Collider c)
    {    
        if(c.gameObject.tag == "Player"){
          DeathMeshToActivate.SetActive(true);
          DeathMeshToDeActivate1.SetActive(false);
          DeathMeshToDeActivate2.SetActive(false);
          DeathMeshToDeActivate3.SetActive(false);
          Debug.Log("Changed");
        }    
    }

}
