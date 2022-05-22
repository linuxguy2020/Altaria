using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController: MonoBehaviour
{
    
	 //SERIALIZE FIELD
	 [SerializeField] private GameObject FireSphere;
	 [SerializeField] private GameObject WindSphere;
	 [SerializeField] private GameObject WaterSphere;
	 [SerializeField] private Transform point;
	 //VARIABLES
	 private KeyCode lastKey;
	 private Animator animator;
	 private Camera _camera;
	 private GameObject magicSphere;
	 private bool canShoot = true;
	 
	void Start(){
		//Inizializzo i componenti camera ed animator
		_camera=GetComponent<Camera>();
		animator = GetComponent<Animator>();
		
		lastKey = KeyCode.Alpha1; // Valore di default per la scelta del potere
	}
	void Update()
	{
		//CONTROLLA L'ULTIMO POTERE MAGICO SELEZIONATO VEDI SEZIONE *UTILS*
		checkLastInput();

		
		if (canShoot == true)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) )
			{
				canShoot = false;
				//PARTE IL RAYCAST SEGUENDO LA POSIZIONE DEL MOUSE
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				StartCoroutine(Attack()); // START DELLA COROUTINE ATTACCO
				
				if (Physics.Raycast(ray, out hit))
				{
					//Debug.Log("Hit");
				}
				else
				{
					//Debug.Log("Not Hit");
				}

			}
		}
	}


private IEnumerator Attack()
 {
		
		if (animationAttackIsFinished()) //VERIFICA CHE ENTRAMBE LE ANIMAZIONI SIANO TERMINATE VEDI SEZIONE *UTILS*
		{
			//VERIFICA LA ROTAZIONE DELLA TELECAMERA IN MODO TALE DA FARE L'ANIMAZIONE ESATTA
			if (Camera.main.transform.eulerAngles.x >= 316f && Camera.main.transform.eulerAngles.x <= 335f) 
			{
				//PARTE L'ANIMAZIONE ED ASPETTA 0.9F SECONDI PRIMA DI ISTANZIARE LA SFERA
				animator.SetLayerWeight(animator.GetLayerIndex("AttackUp"), 1);
				animator.SetTrigger("AttackUp");
				yield return new WaitForSeconds(0.9f);
			Instantiate(); //ISTANZIA, VEDI *UTILS*
				
			 }
			else
			{
				//PARTE L'ANIMAZIONE ED ASPETTA 0.9F SECONDI PRIMA DI ISTANZIARE LA SFERA
				animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
				animator.SetTrigger("Attack");
				yield return new WaitForSeconds(0.9f);
				Instantiate(); //ISTANZIA, VEDI *UTILS*
			}
		}
		
		canShoot = true;
 }
 
//UTILS
	private void Instantiate()
	{
		//CONTROLLA IL VALORE DI LASTKEY CHE VIENE SETTATO DAL METODO CHECKLASTINPUT() ED INSTANZIA LA SFERA CON IL POTERE SELEZIONATO
		if (lastKey == KeyCode.Alpha1)
		{
			magicSphere = GameObject.Instantiate(FireSphere, point.position, 
			Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 
				Camera.main.transform.eulerAngles.z));

		}
		else if (lastKey == KeyCode.Alpha2)
		{
			magicSphere = GameObject.Instantiate(WindSphere, point.position, 
			Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 
				Camera.main.transform.eulerAngles.z));

		}
		else if (lastKey == KeyCode.Alpha3)
		{
			magicSphere = GameObject.Instantiate(WaterSphere, point.position, 
			Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 
				Camera.main.transform.eulerAngles.z));

		}
	}
	
	private void checkLastInput()
	{
		//AL CLICK DEI TASTI 1,2,3 SI SALVA L'ULTIMO SELEZIONATO
		bool notPressed = true;
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			lastKey = KeyCode.Alpha1;
			notPressed = false;

		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			lastKey = KeyCode.Alpha2;
			notPressed = false;

		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			lastKey = KeyCode.Alpha3;
			notPressed = false;
		    
		}
		else if (!notPressed)
		{
		lastKey = KeyCode.Alpha1; 
		
		}
	}

	private bool animationAttackIsFinished()
	{
		//GRAZIE AL VALORE "normalizedTime" POSSIAMO SAPERE SE UN ANIMAZIONE E' FINITA
		//SE E' COMPRESO TRA 0 ED 1 L'ANIMAZIONE E' IN ESECUZIONE
		//SE E' MAGGIORE DI 1 L'ANIMAZIONE E' TERMINATA
		if (animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Attack")).normalizedTime >= 1
		    && animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("AttackUp")).normalizedTime >= 1)
		{
			return true;
		}

		return false;

	}

}
