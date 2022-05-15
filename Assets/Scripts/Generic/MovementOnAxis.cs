using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOnAxis : MonoBehaviour
{
    //velocità di movimento
    public float speed = 0.3f;
    //lunghezza movimento positivo
    public float positiveLength = 1.0f;
    //lunghezza movimento negativo
    public float negativeLength = 1.0f;
    //asse su cui viene eseguito il movimento
    public char axis = 'x';
    //variabile da utilizzare per fermare il movimento
    public bool moving = false;
    //indicatore della direzione dello spostamento
    public bool positiveDirection = true;

    //posizione iniziale oggetto
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    //metodo che salva la posizione iniziale dell'oggetto
    void Initialize()
    {
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void ActivateMovement()
    {
        moving = true;
    }

    //metodo che muove l'oggetto, se configurato per farlo
    void Move()
    {
        if (moving == true)
        {
            ManageMovement();
        }

    }

    //metodo che gestisce il movimento per i vari assi, di default l'asse è x anche in caso di input non corretto
    void ManageMovement()
    {
        if (axis == 'y')
        {
            if (positiveDirection == true)
            {
                // move up
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (transform.position.y >= spawnPos.y + positiveLength)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move down
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (transform.position.y <= spawnPos.y - negativeLength)
                {
                    positiveDirection = true;
                }
            }
        }
        else if (axis == 'z')
        {
            if (positiveDirection == true)
            {
                // move forward
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if (transform.position.z >= spawnPos.z + positiveLength)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move back
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                if (transform.position.z <= spawnPos.z - negativeLength)
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
                if (transform.position.x >= spawnPos.x + positiveLength)
                {
                    positiveDirection = false;
                }
            }
            else
            {
                // move left
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x <= spawnPos.x - negativeLength)
                {
                    positiveDirection = true;
                }
            }
        }
    }
}
