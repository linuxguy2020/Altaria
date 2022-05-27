using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        StartCoroutine(CreditsHandler());
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    //The coroutine change at a specific second the correct credits text and fade it
    IEnumerator CreditsHandler()
     {
        yield return new WaitForSeconds(5.5f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Gamer's Dreams presented - Altaria -";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Giovanni Annuzzi";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Paolo Boca";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Simone Lucà";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Tommaso Ruga";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        //gameObject.GetComponent<UnityEngine.UI.Text>().fontSize = 40;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "This work was made under the supervision of Professor Carmelo Macrì";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "During Virtual Reality Course A.A. 2021-2022";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Università della Calabria";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Dipartimento di Matematica e Informatica (DeMaCS)";
        anim.Play("CreditsFader",  -1, 0f);
        yield return new WaitForSeconds(8.5f);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Copyright 2022";
        anim.Play("CreditsFader",  -1, 0f);
     }
}
