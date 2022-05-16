using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //Get the column to unlock and its position
    [SerializeField] private GameObject ColumnToMove;
    private Vector3 pos;
    private Vector3 pos1;
    private int pressed = 0;
    public bool negative = false;

    //Update the column y axis (increase by 3 units)
    private void MoveGameObject()
    {
        pos = ColumnToMove.transform.position;
        float x = pos[0];
        float y = pos[1] + 6.0f;
        float z = pos[2];
        ColumnToMove.transform.position = new Vector3(x, y, z);
    }

    //Update the button position
    private void UpdateButtonPosition(){
        pos1 = gameObject.transform.localPosition;
        float x = pos1[0];
        float y = pos1[1];
        float z;
        if(negative){
            z = pos1[2] - 0.20f;
        }
        else{
            z = pos1[2] + 0.20f;
        }
        gameObject.transform.localPosition = new Vector3(x, y, z);
    }

    //When the player hit the button with a specific enchantment, the button will be activated
    private void OnTriggerEnter(Collider c)
    {    
        if(c.gameObject.name == "Dyonisus"){
          StartCoroutine(UnlockColumn());
        }    
    }

    //On button pression, the column will appear and state pressed set to 1
    IEnumerator UnlockColumn()
     {
         if(pressed == 0){
            UpdateButtonPosition();
            yield return new WaitForSeconds(0.5f);
            MoveGameObject();
            pressed = 1;
         }
     }
}
