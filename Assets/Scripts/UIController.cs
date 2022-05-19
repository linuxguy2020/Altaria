using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
	public Image fire;
	public Image wind;
	public Image water;
    
	// Start is called before the first frame update
    void Start()
    {
        defaultPower();
    }

    // Update is called once per frame
    void Update()
    {
        SetMagicPower();
	}


	void SetMagicPower(){

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			fire.enabled=true;
			wind.enabled=false;
			water.enabled=false;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2)){
			fire.enabled=false;
			wind.enabled=true;
			water.enabled=false;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3)){
			fire.enabled=false;
			wind.enabled=false;
			water.enabled=true;
		}
	}



	void defaultPower(){
		fire.enabled=true;
		wind.enabled=false;
		water.enabled=false;
	}


}
