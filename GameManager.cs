using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public static GameObject interactibleText;

    public static GameObject GetInteractibleText()
    {
        return interactibleText;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
