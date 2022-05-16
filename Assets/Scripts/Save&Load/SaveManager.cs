using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    //This script manages the behavior of save and load system in the game. It is keep alive with the GameManager object (that is DontDestroy on Load type)
    //All other scripts and scenes ask it to save or load data in the game
    public int Intro;
    public int Tutorial;
    public int Crystal1;
    public int Crystal2;

    // Create a field for the save file.
    string saveFile;

    void Awake(){
        //Define a path for save data inside Saves Folder in Assets Folder
        saveFile = Application.dataPath + "/Saves/MySaveData.json";
    }

    //Create a first json save data where all values are zero 
    public void FirstSaveGameManager()
    {
        SaveData data = new SaveData();  
	    data.savedIntro = 0;
	    data.savedTutorial = 0;
	    data.savedCrystal1 = 0;
        data.savedCrystal2 = 0;
        Intro = 0;
        Tutorial = 0;
        Crystal1 = 0;
        Crystal2 = 0;
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(data);
        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }

    //Load previous game status from json 
    public void LoadGameManager()
    {
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
            Intro = data.savedIntro;
            Tutorial = data.savedTutorial;
            Crystal1 = data.savedCrystal1;
            Crystal2 = data.savedCrystal2;
        }
    }

    //This method is used by Temple scene to determinate the status of the game and load or not some objects like crystals and end portal
    public int[] LoadSceneStateManager()
    {
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);

            int[] state = new int[3];
            if(Crystal1 == 1){
                state[0] = 1;
            }
            if(Crystal2 == 1){
                state[1] = 1;
            }
            if(Crystal1 == 1 && Crystal2 == 1){
                state[2] = 1;
            }
            return state;
        }
        else return null;
    }

    //When the tutorial is complete, on enter for the first time in to Temple, Tutorial fiels is set to one
    public void TutorialCompleteMananger(){
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
            data.savedIntro = 1;
	        data.savedTutorial = 1;
            Intro = 1;
            Tutorial = 1;
	        // Serialize the object into JSON and save string.
            string jsonString = JsonUtility.ToJson(data);
            // Write JSON to file.
            File.WriteAllText(saveFile, jsonString);
        }
    }

    //When the intro is complete, on enter for the first time in Tutorial, Intro fiels is set to one
    public void IntroCompleteManager(){
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
            data.savedIntro = 1;
            Intro = 1;
	        // Serialize the object into JSON and save string.
            string jsonString = JsonUtility.ToJson(data);
            // Write JSON to file.
            File.WriteAllText(saveFile, jsonString);
        }
    }

    //When a crystal x is taken, crystal x field is set to one
    public void CrystalTakenManager(int CrystalNumber){
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
            if(CrystalNumber == 1){
                data.savedCrystal1 = 1;
                Crystal1 = 1;
            }
            if(CrystalNumber == 2){
                data.savedCrystal2 = 1;
                Crystal2 = 1;
            }
	        // Serialize the object into JSON and save string.
            string jsonString = JsonUtility.ToJson(data);
            // Write JSON to file.
            File.WriteAllText(saveFile, jsonString);
        }
    }

    //A test method to set, on trigger test cube collider, all fields to one and test the save load system in the game
    public void TestSaveData(){
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);
            // Deserialize the JSON data into a pattern matching the SaveData class.
            SaveData data = JsonUtility.FromJson<SaveData>(fileContents);
            data.savedIntro = 1;
            data.savedTutorial = 1;
            data.savedCrystal1 = 1;
            data.savedCrystal2 = 1;
            Intro = 1;
            Tutorial = 1;
            Crystal1 = 1;
            Crystal2 = 1;
	        // Serialize the object into JSON and save string.
            string jsonString = JsonUtility.ToJson(data);
            // Write JSON to file.
            File.WriteAllText(saveFile, jsonString);
        }
    }
    
}
