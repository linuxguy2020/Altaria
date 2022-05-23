using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //Get the column to unlock and its position
    [SerializeField] private GameObject ColumnToMove;
    [SerializeField] private GameObject Symbol;
    public Material newMat;
    private Vector3 pos;
    private int pressed = 0;

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
    private void UpdateButton(){
        //Change symbol texture to active
        Symbol.GetComponent<MeshRenderer>().material = newMat;
    }

    //When the player hit the button with a specific enchantment, the button will be activated
    private void OnTriggerEnter(Collider c)
    {    
        if(c.gameObject.tag == "WindPower"){
          StartCoroutine(UnlockColumn());
        }    
    }

    //On button pression, the column will appear and state pressed set to 1
    IEnumerator UnlockColumn()
     {
         if(pressed == 0){
            UpdateButton();
            yield return new WaitForSeconds(0.5f);
            MoveGameObject();
            pressed = 1;
         }
     }
}
