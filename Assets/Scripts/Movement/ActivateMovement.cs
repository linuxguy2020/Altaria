using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lo script si occupa di assegnare il ruolo di sveglia al figlio prescelto (indicato dal parametro di step)
// tale figlio al verificarsi di una condizione notificherà il padre che attiverà il movimento di tutti i figli
public class ActivateMovement : MonoBehaviour
{
    public int afterStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if (i == afterStep)
            {
                PlatformAttach platformAttach = transform.GetChild(i).GetComponent<PlatformAttach>();
                if(platformAttach != null)
                {
                    platformAttach.AwakeMovementOnTrigger();
                }
            }
        }
    }

    //Attiva il movimento di ogni figlio
    public void StartMovement()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            MovementOnAxis movementOnAxis = transform.GetChild(i).GetComponent<MovementOnAxis>();
            if(movementOnAxis != null)
            {
                movementOnAxis.enabled=true;
            }

            Falling falling = transform.GetChild(i).GetComponent<Falling>();
            if (falling != null)
            {
                falling.enabled = true;
            }
        }
    }
}
