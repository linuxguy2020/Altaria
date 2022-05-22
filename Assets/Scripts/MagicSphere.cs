using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSphere : MonoBehaviour
{
   private Rigidbody magicSphereRigidBody;
   public float speed=10.0f;
   private float timeToDestroy = 3f;
   
   private void Start()
   {
	   magicSphereRigidBody = GetComponent<Rigidbody>(); 
	   //MUOVE LA SFERA
	   magicSphereRigidBody.velocity = transform.forward * speed;
       //DISTRUGGE LA SFERA MAGICA DOPO LA SCADENZA DI UN TEMPO FISSATO
	   Destroy(gameObject,timeToDestroy);
       
    }

   //DISTRUGGE LA SFERA MAGICA A SEGUITO DI UNA COLLISIONE
   private void OnTriggerEnter(Collider coll)
   {
	   Destroy(gameObject);
   }
}
