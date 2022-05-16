using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public int startAtStep = 0;

    //Assegna ad un componente figlio il ruolo di sveglia del movimento 
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if(i == startAtStep)
            {
                transform.GetChild(i).SendMessage("AwakeMovementOnTrigger", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    //Attiva il movimento di ogni figlio
    void StartMovement()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i) { 
            transform.GetChild(i).SendMessage("ActivateMovement", SendMessageOptions.DontRequireReceiver);
        }
    }
}
