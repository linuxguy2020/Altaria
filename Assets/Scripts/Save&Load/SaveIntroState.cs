using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveIntroState : MonoBehaviour
{
    private GameObject GameManager;

    //On start, search the game manager object and call Intro complete method
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        IntroComplete();
    }

    //Call the intro complete manager in to Game Manager
    void IntroComplete(){
        GameManager.GetComponent<SaveManager>().IntroCompleteManager();
    }
}
