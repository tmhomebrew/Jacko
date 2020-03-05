using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoneLogic : MonoBehaviour
{
    GameObject _cardHolder;
    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        foreach (Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.tag.ToLower() == "cardholder")
            {
                _cardHolder = go.gameObject;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
