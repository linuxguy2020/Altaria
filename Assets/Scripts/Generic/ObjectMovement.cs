using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public float speed = 0.3f;
    public float range = 1.0f;
    public char axis = 'x';

    public bool moving = false;
    public bool falling = false;
    public GameObject Player;



    private bool positiveDirection = true;
    private Vector3 spawnPos;
    private bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    void init()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveColumn();
    }

    void moveColumn()
    {
        if(moving == true)
        {
            manageMovement();
        }
        if(falling == true)
        {
            manageFall();
        }
    }
    void manageMovement()
    {
        if(axis =='y')
        {
            if (positiveDirection == true)
            {
                // move right
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (transform.position.y >= spawnPos.y + range)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move left
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (transform.position.y <= spawnPos.y - range)
                {
                    positiveDirection = true;
                }
            }
        }
        else if (axis == 'z')
        {
            if (positiveDirection == true)
            {
                // move right
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (transform.position.z >= spawnPos.z + range)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move left
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                if (transform.position.z <= spawnPos.z - range)
                {
                    positiveDirection = true;
                }
            }
        }
        else
        {
            if (positiveDirection == true)
            {
                // move right
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (attached == true)
                {
                    Player.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                if (transform.position.x >= spawnPos.x + range)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move left
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (attached == true)
                {
                    Player.transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                if (transform.position.x <= spawnPos.x - range)
                {
                    positiveDirection = true;
                }
            }
        }
    }

    void manageFall()
    {
        transform.Translate(Vector3.down * 5.8f * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collisione con:" + other.name);
        if (other.gameObject == Player)
        {
            attached = true;
            /*Debug.Log("Collisione con player:");
            lastTransform = Player.transform.parent.transform.parent;
            Debug.Log("Ultimo transform:" + lastTransform.name);
            Debug.Log("Nuovo transform:" + transform.name);
            Player.transform.parent.transform.parent = transform;*/
        }
    }

     private void OnTriggerExit(Collider other)
     {
         Debug.Log("Uscita dalla collisione con:" + other.name);
         if (other.gameObject == Player)
         {
            attached = false;
         }
     }
}
