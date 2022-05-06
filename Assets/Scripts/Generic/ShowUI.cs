using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    //object that will be deisplayed
    public GameObject uiObject;

    // start as false so image is not shown
    void Start()
    {
        uiObject.SetActive(false);
    }

    // the object that collides needs be be tagged "Player"
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);

            // coroutine must be started befire ienumerator funcion is called.
            // takes parameter as string.
            StartCoroutine("WaitForSec");
        }
    }

    // use real time seconds to wait
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);

        // destroy image
        Destroy(uiObject);

        //destroy cube that has been triggered
        Destroy(gameObject);
    }
}
