using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class SubjugateWitch : InteractibleClass
{
    [SerializeField]
    GameObject gigglingWitch;

    [SerializeField]
    SanityHandler playerSanity;

    [SerializeField]
    Light redLight;

    [SerializeField]
    GameObject redLightModel;

    [SerializeField]
    Material greenLightMaterial;

    [SerializeField]
    GameObject knockOutGas;

    [SerializeField]
    GameObject sanityMeter;

    [SerializeField]
    GameObject playerLaughter;

    [SerializeField]
    [TextArea]
    string loreInfo;

    bool inPanel = false;

    GameObject interactibleText;

    //[SerializeField]
    GameObject lorePanel;

    GameObject terminalAccessSound;

    private void Awake()
    {
        interactibleText = GameObject.FindGameObjectWithTag(TagHolder.InteractibleText);
        interactibleText.GetComponent<TextMeshProUGUI>().text = TextStrings.originalInteractableText;
        lorePanel = GameObject.FindGameObjectWithTag(TagHolder.LorePanel);
    }

    void Start()
    {
        interactibleText.SetActive(false);
        lorePanel.SetActive(false);

        terminalAccessSound = GameObject.FindGameObjectWithTag(TagHolder.TerminalSound);
    }

    protected override void ActivateInteraction()
    {
        if(gigglingWitch)
        {
            Destroy(gigglingWitch);
            playerSanity.enabled = false;
            sanityMeter.SetActive(false);
            playerLaughter.SetActive(false);
            knockOutGas.SetActive(true);
            redLightModel.GetComponent<Renderer>().material = greenLightMaterial;
            redLight.color = new Color(0f, 1f, 0f);
        }

        if (!inPanel)
        {
            lorePanel.GetComponentInChildren<TextMeshProUGUI>().text = loreInfo;
            lorePanel.SetActive(true);
            terminalAccessSound.GetComponent<AudioSource>().Play();
            interactibleText.GetComponent<TextMeshProUGUI>().text = TextStrings.panelInteractableText;
            Time.timeScale = 0f;
            inPanel = true;
        }
        else
        {
            DeactivateInteraction();
        }
        return;
    }

    protected override void DeactivateInteraction()
    {
        lorePanel.SetActive(false);
        if (inPanel)
            terminalAccessSound.GetComponent<AudioSource>().Play();
        interactibleText.GetComponent<TextMeshProUGUI>().text = TextStrings.originalInteractableText;
        Time.timeScale = 1f;

        inPanel = false;

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
}
