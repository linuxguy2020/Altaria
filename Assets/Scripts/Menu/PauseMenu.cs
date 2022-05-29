using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Scene _actualScene; //get the actual active scene
    // Start is called before the first frame update
    void Start()
    {
        //when start, the actual scene is setted and if its name is Temple or Tutorial, deactive the return to Temple text and button
        _actualScene = SceneManager.GetActiveScene(); 
        if(_actualScene.name == "Temple" || _actualScene.name == "Tutorial"){
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    //restore the normal state of the game(mouse cursor state and time state) and than change or reload the scene, due to button pressed
    public void BackToMenu(){
        RestoreNormalState();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene(){
        RestoreNormalState();
        SceneManager.LoadScene(_actualScene.name);
    }

    public void BackToTemple(){
        RestoreNormalState();
        SceneManager.LoadScene("Temple");
    }

    void RestoreNormalState(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
