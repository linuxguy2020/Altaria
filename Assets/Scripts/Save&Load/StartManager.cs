using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject StartMenu;

    private GameObject GameManager;

    //On start, search the game manager object and call load game method
    void Start(){
        GameManager = GameObject.Find("GameManager");
        LoadGame();
    }

    //Call the first save manager in Game Manager
    void FirstSaveGame()
    {
        GameManager.GetComponent<SaveManager>().FirstSaveGameManager();
    }

    //Call the load manager in Game Manager
    void LoadGame()
    {
        GameManager.GetComponent<SaveManager>().LoadGameManager();
    }

    //Delete save data file 
    void EraseData()
    {
	    if (File.Exists(Application.dataPath + "/Saves/MySaveData.json"))
	    {
		    File.Delete(Application.dataPath + "/Saves/MySaveData.json");
            Debug.Log("Game data erased!");
        }
        else
            Debug.LogError("There is no data to erase!");
    }

    //Manage the game start: if intro field is equal to 0, it's the first time that game is started. Else, the start menu is showed
    public void StarterManager(){
        if(GameManager.GetComponent<SaveManager>().Intro == 0){
            FirstSaveGame();
            SceneManager.LoadScene("IntroScene");
        }
        else{
            MainMenu.SetActive(false);
            StartMenu.SetActive(true);
        }
    }

    //If the tutorial field is set to 0, the player hasn't complete tutorial level, so the game continue in Tutorial scene. Else the temple is loaded
    public void ContinueManager(){
        if(GameManager.GetComponent<SaveManager>().Tutorial == 0){
            SceneManager.LoadScene("Tutorial");
        }
        else{
            SceneManager.LoadScene("Temple");
        }
    }

    //If human player, decide to restart the game, all data will be erased and will be create a new save data. After the Intro scene will be loaded
    public void RestartManager(){
        EraseData();
        FirstSaveGame();
        SceneManager.LoadScene("IntroScene");
    }

    //A simple method to close the application
    public void QuitGame(){
        Application.Quit();
    }
}

