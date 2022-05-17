using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadChatedralState : MonoBehaviour
{
    //This scripts load the progress done in the game and set the correct status of the Chatedral

    public GameObject OBJEndPortal;
    public GameObject OBJCrystal1;
    public GameObject OBJCrystal2;

    private GameObject GameManager;

    //On start the crystals and end portal are set to inactive. Only if their save fields, on load data, are one, they will be set to active. 
    //However, the tutorial field is set to one if the player is entering for the first time in to chatedral 
    void Start(){
        GameManager = GameObject.Find("GameManager");
        OBJCrystal1.SetActive(false);
        OBJCrystal2.SetActive(false);
        OBJEndPortal.SetActive(false);
        LoadSceneState();
        if(GameManager.GetComponent<SaveManager>().Tutorial == 0){
            TutorialComplete();
        }
    }

    //Load temple status, after invoke the scene status manager in GameManager
    void LoadSceneState()
    {
        int[] actualState = GameManager.GetComponent<SaveManager>().LoadSceneStateManager();
        if(actualState[0] == 1){
            OBJCrystal1.SetActive(true);
        }
        if(actualState[1] == 1){
            OBJCrystal2.SetActive(true);
        }
        if(actualState[2] == 1){
            OBJEndPortal.SetActive(true);
        }
    }

    //Invoke the tutorial manager in GameManager to set Tutorial to one
    void TutorialComplete(){
        GameManager.GetComponent<SaveManager>().TutorialCompleteMananger();
    }

}
