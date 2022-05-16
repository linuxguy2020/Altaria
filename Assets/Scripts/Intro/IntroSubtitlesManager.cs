using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSubtitlesManager : MonoBehaviour
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
        yield return new WaitForSeconds(6);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Maybe...";
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "You have already seen it in some of your dreams";
        yield return new WaitForSeconds(4);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Or you've heard of it";
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "in the oldest legends";
        yield return new WaitForSeconds(2.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Altaria";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "a magical place where all realties collide";
        yield return new WaitForSeconds(4);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "The demons";
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "have destroyed the balance of the world";
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "and now chaos reigns everywhere.";
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Only you can restore order";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "The world needs you";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Wake up Dyonisus!";
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
     }
}
