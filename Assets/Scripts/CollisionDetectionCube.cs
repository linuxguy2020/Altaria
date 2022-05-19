using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionCube : MonoBehaviour
{
	public Material fireMaterial;
	public Material waterMaterial;
	public Material windMaterial;

	public Material coalMaterial;
	
	private Vector3 newPosition;
	private ParticleSystem.MainModule pMain;

	private ParticleSystem ps;
	
	
	
	void Start()
	{
		ps = GetComponent<ParticleSystem>();
		if (gameObject.tag == "CoalCube")
		{
			
			//pMain =ps.main;
			ps.Stop();
		}
		//newPosition = transform.position;
		
		
	}

	private void OnTriggerEnter(Collider col)
	{
		if (gameObject.tag == "FireCube")
		{
			//SE è UN CUBO DI FUOCO PUOI SOLO UTILIZZARE L'ACQUA PER RENDERLO CARBONE
			if (col.gameObject.tag == "WaterPower")
			{
				GetComponent<MeshRenderer>().material = coalMaterial;
				GetComponent<ParticleSystem>().Stop(); 
				gameObject.tag = "CoalCube";
			}

		}
		else if (gameObject.tag == "WaterCube")
		{
			//SE E' UN CUBO DI ACQUA CON IL FUOCO PUOI RENDERLO VAPORE PER SPOSTARLO
			if (col.gameObject.tag == "FirePower")
			{
				GetComponent<MeshRenderer>().material = windMaterial;
			}
		}
		//SE E UN CUBO DI CARBONE PUOI RIACCENDERLO, DISTRUGGERLO E SPOSTARLO CON TUTTI E 3 I POTERI
		else if (gameObject.tag == "CoalCube")
		{
			if (col.gameObject.tag == "FirePower")
			{
				GetComponent<MeshRenderer>().material = fireMaterial;
				GetComponent<ParticleSystem>().Play();
				//pMain.startSize = new ParticleSystem.MinMaxCurve(0.5f, 1f);
				gameObject.tag = "FireCube";
			}
			else if (col.gameObject.tag == "WaterPower")
			{
				Destroy(gameObject);
			}
			else if (col.gameObject.tag == "WindPower")
			{
				/*Vector3 dir = transform.position - col.gameObject.transform.position;
				Debug.Log("Dir x: "+dir.x+" Dir y: "+dir.y+" Dir z: "+dir.z);
				if (dir.x > 0)
				{ 
					//transform.Translate (1f, 0f, 0f);
				}
				if(dir.x < 0)
				{
					transform.Translate (-1f, 0f, 0f);
				}
				/*if(dir.z>0)
				{
					transform.Translate (0f, 0f, 1f);
				}
				if(dir.z<0)
				{
					transform.Translate (0f, 0f, -1f);
				}
				*/
				
					
				
			}
		}
	}

}	
	
	
