using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public bool isPaused = false; //check if the game is paused or not
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){ //When press p, pause the game if it isn't paused, and unpause if it is paused
            if(isPaused == false){
                Open(); 
            }
            else{
                Close();
            }
        }
    }

    //Activate the cursor, set the game state to pause and stop time
    public void PauseGame (){ 
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    //restore the normal state of the game
    public void UnPauseGame (){
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    //The first child of Pause handler, the pause menu, is setted active or not by specific situation
    public void Open() {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        PauseGame();
    }

    public void Close() {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        UnPauseGame();
    }



}
