using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverSample : MonoBehaviour
{
    public PlayerHand _myPlayerHand;

    private void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        _myPlayerHand = GetComponentInParent<PlayerHand>();
    }

    private void OnMouseDown()
    {
        try
        {
            if (_myPlayerHand.CardsInHand.Contains(transform.gameObject))
            {
                _myPlayerHand.SelectCard(transform.gameObject);
            }
        }
        catch (System.Exception)
        {
            print("Could not select card - Not part of Hand");
        }
    }

    private void OnMouseExit()
    {
        try
        {
            if (_myPlayerHand.CardsInHand.Contains(transform.gameObject))
            {
                _myPlayerHand.HoverOverCancel(transform.gameObject);
            }
        }
        catch (System.Exception)
        {
            print("Could not Hover Over card - Not part of Hand");
        }
    }

    private void OnMouseEnter()
    {
        try
        {
            if (_myPlayerHand.CardsInHand.Contains(transform.gameObject))
            {
                _myPlayerHand.HoverOverCard(transform.gameObject);
            }
        }
        catch (System.Exception)
        {
            print("Could not Hover Over card - Not part of Hand");
        }
    }
}
