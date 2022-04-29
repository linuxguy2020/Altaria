using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    //this script changes the scene, based on the passed id, 
    //as soon as the mesh to which it is attached is touched, for example portal mesh
    //loading is done with a slight delay to allow the fade in animation to complete

    [SerializeField] private GameObject white;
    public int SceneId = 0;
    public float delay = 0;

    void Start(){
      white.GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Ch39"){
          StartCoroutine(LoadLevelAfterDelay(delay));
        }    
   }

   IEnumerator LoadLevelAfterDelay(float delay)
     {
         white.GetComponent<Animator>().enabled = true;
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(SceneId);
     }

}