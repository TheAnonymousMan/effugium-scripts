using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class KeyCardHandler : InteractibleClass
{
    [SerializeField]
    GameObject door;
        
    GameObject collectedText;

    [SerializeField]
    string itemName;

    GameObject keyCollectionSound;
    
    GameObject interactibleText;

    private void Awake()
    {
        interactibleText = GameObject.FindGameObjectWithTag(TagHolder.InteractibleText);
        interactibleText.GetComponent<TextMeshProUGUI>().text = TextStrings.originalInteractableText;

        collectedText = GameObject.FindGameObjectWithTag(TagHolder.MessageText);
    }

    // Start is called before the first frame update
    void Start()
    {
        interactibleText.SetActive(false);
        collectedText.SetActive(false);
        keyCollectionSound = GameObject.FindGameObjectWithTag(TagHolder.KeycardSound);
    }

    protected override void ActivateInteraction()
    {
        StartCoroutine(DisplayMessage());
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        keyCollectionSound.GetComponent<AudioSource>().Play();
        canInteract = false;
        Destroy(door);
        DeactivateText();
        return;
    }

    protected override void DeactivateInteraction()
    {
        return;
    }

    protected override void ActivateText()
    {
        interactibleText.SetActive(true);
        return;
    }

    protected override void DeactivateText()
    {
        interactibleText.SetActive(false);
        return;
    }

    private IEnumerator DisplayMessage()
    {
        collectedText.GetComponent<TextMeshProUGUI>().text = $"Obtained {itemName}!";
        collectedText.SetActive(true);

        yield return new WaitForSeconds(2f);

        collectedText.SetActive(false);
    }
}