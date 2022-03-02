using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InteractibleClass : MonoBehaviour
{
    protected bool canInteract = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canInteract)
        {
            ActivateInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;
            DeactivateText();
            DeactivateInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!(Vector3.Dot(gameObject.transform.forward, other.gameObject.transform.forward) < 0
                    && Vector3.Dot(gameObject.transform.forward, other.gameObject.transform.forward) > -1))
            {
                canInteract = false;
                DeactivateText();
                DeactivateInteraction();                
            }
            else
            {
                canInteract = true;

                ActivateText();                
            }
        }
    }

    protected abstract void ActivateInteraction();
    protected abstract void DeactivateInteraction();
    protected abstract void ActivateText();
    protected abstract void DeactivateText();
}
