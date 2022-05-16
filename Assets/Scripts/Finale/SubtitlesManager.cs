using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        StartCoroutine(SubtitlesHandler());
    }

    //The coroutine change at a specific second the correct subtitle text
    IEnumerator SubtitlesHandler()
     {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Balance has been restored";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "The world is safe";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Farewell, Dyonisus...";
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
     }
}
