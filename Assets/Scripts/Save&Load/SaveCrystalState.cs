using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveCrystalState : MonoBehaviour
{
    private GameObject GameManager;
    public int CrystalNumber;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    //On start, search the game manager object
    void Start(){
        GameManager = GameObject.Find("GameManager");
    }

    //Call the crystal taken manager in to Game Manager and play Crystal Taken sound. 
    //Also, crystal box collider will be deactivated and scale reduced, and pointlight child deactivated
    void CrystalTaken(){
        audioSource.PlayOneShot(clip, volume);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.transform.GetChild(7).gameObject.SetActive(false);
        GameManager.GetComponent<SaveManager>().CrystalTakenManager(CrystalNumber);
    }

    //If player collides with crystal, crystal taken method is invoked and the crystal is destroyed from the scene
    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Dyonisus"){
          CrystalTaken();
        }    
   }
}
