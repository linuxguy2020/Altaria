using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController: MonoBehaviour
{
    
	 [SerializeField] private GameObject sphere;
	 [SerializeField] private Transform point;
	 private Animator animator;
	 private Camera _camera;
	 private int clickCounter = 0;

	void Start(){
		_camera=GetComponent<Camera>();
		animator = GetComponent<Animator>();
	}
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			clickCounter += 1;
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
				StartCoroutine(Attack());
			if(Physics.Raycast(ray,out hit))
			{
			  //Debug.Log("Hit");
			}
			else{
			  //Debug.Log("NOT");
			}
		}
	}
	
private void Instantiate()
{
	GameObject magicSphere = GameObject.Instantiate(sphere, point.position, 
		Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 
			Camera.main.transform.eulerAngles.z));
}
private IEnumerator Attack()
 {
	 
	 if(Camera.main.transform.eulerAngles.x >= 316f && Camera.main.transform.eulerAngles.x <= 335f)
	 {
		 animator.SetLayerWeight(animator.GetLayerIndex("AttackUp"), 1);
		 animator.SetTrigger("AttackUp");
		 yield return new WaitForSeconds(1f);
		 Instantiate();
	 }
	 else
	 {
		 animator.SetLayerWeight(animator.GetLayerIndex("Attack"), 1);
		 animator.SetTrigger("Attack");
		 yield return new WaitForSeconds(1f);
		 Instantiate();
	 }
	 

	 

 }

}
