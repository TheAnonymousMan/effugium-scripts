using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityActivator : MonoBehaviour
{
    [SerializeField]
    private SanityHandler playerSanityHandler;

    [SerializeField]
    private GameObject gigglingWitchSound;

    [SerializeField]
    private GameObject playerInsanitySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Collision happens");
            // initiate laughter and sanity script
            gigglingWitchSound.SetActive(true);
            playerInsanitySound.SetActive(true);

            playerSanityHandler.enabled = true;
        }
    }
}
