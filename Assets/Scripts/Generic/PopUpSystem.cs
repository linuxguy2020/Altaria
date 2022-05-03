using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// pop up system.
// spawns a pop up type dialog box with custom text

public class PopUpSystem : MonoBehaviour
{
    // generic object of popup system
    public GameObject popUpBox;

    // reference to the Animator of the popup system.
    // this is needed because animations and triggers are used
    // in order to handle behaviours
    public Animator animator;

    // generic text
    // TextMeshPro needs to be imported
    public TMP_Text popUpText;

    // function allows text to be added to popup
    public void PopUp(string text)
    {
        // first, set the popup box to be active
        popUpBox.SetActive(true);

        // set the text of the popup to be the
        // text passed in the function
        popUpText.text = text;

        // go with the animator and set
        // the trigger as "pop"
        animator.SetTrigger("pop");
    }
}
