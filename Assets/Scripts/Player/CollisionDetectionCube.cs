using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionCube : MonoBehaviour
{
	//Assegno allo script i materiali che mi servono
	public Material fireMaterial;
	public Material waterMaterial;
	public Material windMaterial;
    public Material coalMaterial;
    //Prefab necessari per gli effetti dei detriti e del vapore
    private GameObject WindCubeInstance;
    [SerializeField] private GameObject WindCube;
    private GameObject DebrisCubeInstance;
    [SerializeField] private GameObject DebrisCube;
	private AudioSource _soundSource;
    [SerializeField] private AudioClip destructionSound;
	[SerializeField] private AudioClip estinguishedSound;
    

	public void Start(){
		 _soundSource = GetComponent<AudioSource>();
	}
	    
	private void OnTriggerEnter(Collider col)
	{
		//Se il cubo ha il tag FireCube
		if (gameObject.tag == "FireCube")
		{
			//Se la sfera con cui collide ha il potere dell'acqua, il cubo diventa di carbone 
			if (col.gameObject.tag == "WaterPower")
			{
				GetComponent<MeshRenderer>().material = coalMaterial; //Cambio il materiale del cubo in carbone
				GetComponent<ParticleSystem>().Stop();  //Fermo il particle
				gameObject.tag = "CoalCube"; //Cambio il tag in Carbone
				_soundSource.PlayOneShot(estinguishedSound); // Questo suono non lo attiviamo nel particle perché non si crea nessun altro oggetto
			}

		}
		//Se il cubo ha il tag WaterCube
		else if (gameObject.tag == "WaterCube")
		{
			//Se la sfera con cui collide ha il potere del fuoco
			if (col.gameObject.tag == "FirePower")
			{
				//L'acqua evapora, creando un cubo vuoto con il particle del vapore , serve solo per creare l'effetto
				WindCubeInstance = GameObject.Instantiate(WindCube, gameObject.transform.position, 
					Quaternion.Euler(0,0,0));
				Destroy(gameObject);
				Destroy(WindCubeInstance, 5f);
				//I suoni di questo effetto sono dentro il particle 



			}
		}
		//Se il cubo ha il tag CoalCube
		else if (gameObject.tag == "CoalCube")
		{
			//Se la sfera con cui collide ha il potere del fuoco
			if (col.gameObject.tag == "FirePower")
			{
				//Riaccendo il carbone in fuoco, cambiando materiale e riattivando il particle
				GetComponent<MeshRenderer>().material = fireMaterial;
				GetComponent<ParticleSystem>().Play();
				gameObject.tag = "FireCube";
			}
			//Se la sfera con cui collide ha il potere dell'acqua
			else if (col.gameObject.tag == "WaterPower")
			{
				//Il cubo viene distrutto,creando un cubo vuoto con il particle dei detriti,serve solo per creare l'effetto
				DebrisCubeInstance = GameObject.Instantiate(DebrisCube, gameObject.transform.position, 
					Quaternion.Euler(0,0,0));
				Destroy(gameObject);
				Destroy(DebrisCubeInstance, 8f);
				
				//I suoni di questo effetto sono dentro il particle 

				
				
				
			}
		}
	}

}	
	
	
