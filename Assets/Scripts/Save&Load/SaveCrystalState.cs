using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveCrystalState : MonoBehaviour
{
    private GameObject GameManager;
    public int CrystalNumber = 1;

    //On start, search the game manager object
    void Start(){
        GameManager = GameObject.Find("GameManager");
    }

    //Call the crystal taken manager in to Game Manager
    void CrystalTaken(){
        GameManager.GetComponent<SaveManager>().CrystalTakenManager(CrystalNumber);
    }

    //If player collides with crystal, crystal taken method is invoked and the crystal is destroyed from the scene
    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Dyonisus"){
          CrystalTaken();
          Destroy(gameObject);
        }    
   }
}
