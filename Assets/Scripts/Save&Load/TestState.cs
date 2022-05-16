using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TestState : MonoBehaviour
{

    private GameObject GameManager;

    void Start(){
        GameManager = GameObject.Find("GameManager");
    }

    void ObjectTaken(){
        GameManager.GetComponent<SaveManager>().TestSaveData();
    }

    private void OnTriggerEnter(Collider c)
   {
        if(c.gameObject.name == "Dyonisus"){
          ObjectTaken();
          gameObject.SetActive(false);
        }    
   }
}