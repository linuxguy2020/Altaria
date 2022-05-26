using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    //this script changes the scene, based on the passed name, 
    //as soon as the mesh to which it is attached is touched, for example portal mesh
    //loading is done with a slight delay to allow the fade in animation to complete
    //When player touches portal the portal sound is played and also its animator, 
    //its mouvements and camera script change their status to disabled.

    [SerializeField] private GameObject white;
    public string SceneName = "MainMenu";
    public float delay = 0;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void Start(){
      white.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Dyonisus"){
          c.gameObject.GetComponent<BasicMovements>().enabled = false;
          c.gameObject.GetComponent<Animator>().enabled = false;
          c.gameObject.GetComponent<CameraController>().enabled = false;
          StartCoroutine(LoadLevelAfterDelay(delay));
        }    
   }

   IEnumerator LoadLevelAfterDelay(float delay)
     { 
         audioSource.PlayOneShot(clip, volume);
         white.GetComponent<Animator>().enabled = true;
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(SceneName);
     }

}