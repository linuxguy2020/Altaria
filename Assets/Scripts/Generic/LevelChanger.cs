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
    private float _actualMusicVolume;
    public float FadeTime = 2.0f;
    private AudioSource music;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void Start(){
      white.SetActive(false);
    }

    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Dyonisus"){
          c.gameObject.GetComponent<BasicMovements>().enabled = false;
          c.gameObject.GetComponent<Animator>().enabled = false;
          c.gameObject.GetComponent<CameraController>().enabled = false;
          music = c.gameObject.transform.GetChild(4).gameObject.GetComponent<AudioSource>();
          FadeMusicOut(music);
          StartCoroutine(LoadLevelAfterDelay(delay));
        }    
   }

   public void FadeMusicOut(AudioSource music){
        _actualMusicVolume = music.volume;
        while (music.volume > 0) {
            music.volume -= 0.1f;
        }
        music.volume = _actualMusicVolume;
   }

   IEnumerator LoadLevelAfterDelay(float delay)
     { 
         audioSource.PlayOneShot(clip, volume);
         white.SetActive(true);
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(SceneName);
     }

}