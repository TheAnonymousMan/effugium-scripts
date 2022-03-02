using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class CreditSequence : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox;

    [SerializeField]
    [TextArea]
    private string[] dialogues;

    [SerializeField]
    private int numberOfDialogues;

    [SerializeField]
    private float timeForDialogues;

    private float timeBetweenDialogue;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenDialogue = timeForDialogues / numberOfDialogues;
        StartCoroutine(DialogueFlow());
    }

    IEnumerator DialogueFlow()
    {
        for (int i = 0; i < numberOfDialogues; i++)
        {
            textBox.text = dialogues[i];
            yield return new WaitForSeconds(timeBetweenDialogue);
        }
        yield break;
    }
}
