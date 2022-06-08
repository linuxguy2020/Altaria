using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float turnSpeed = 15;
	private Camera mainCamera;
	private Transform parent;
	

    private void Start()
    {
	    mainCamera = Camera.main;
	    //Toglie la visualizzazione del cursore
	    Cursor.visible = false;
	    Cursor.lockState = CursorLockMode.Locked;
	    
    }

    //FixedUpdate è utilizzato quando si applicano funzioni relative alla fisica,
    //perché sai che verrà eseguito esattamente in sincronia con il motore fisico stesso.
	void FixedUpdate()
	{
		float cameraRotation = mainCamera.transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, cameraRotation, 0),
			turnSpeed * Time.fixedDeltaTime);
		//Quaternion.Slerp crea l'effetto di una rotazione con velocità angolare uniforme attorno a un asse di rotazione fisso.
		
	}
	
	
}
