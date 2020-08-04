using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverSample : MonoBehaviour
{
    public PlayerHand _myPlayerHand;
    public CardScroller _myScroller;
    public GameObject _myCardHolder;

    float distX;
    IEnumerator cardsMoveFromLeftToRight;
    bool crIsRunning, goingRight;

    private void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        if (transform.name.ToLower().Contains("card"))
        {
            if (transform.GetComponent<CardEditor>().IsDealt)
            {
                _myPlayerHand = GetComponentInParent<PlayerHand>();
                _myScroller = _myPlayerHand.GetComponentInChildren<CardScroller>();
                _myCardHolder = GetComponentInParent<Transform>().parent.gameObject;
                cardsMoveFromLeftToRight = MoveCardsInHand();
            }
        }
        crIsRunning = false;
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
            //if (transform.position.x < _myScroller.LeftSide.transform.position.x)
            //{
            //    distX = Math.Abs(_myScroller.LeftSide.transform.position.x - transform.position.x);
            //    print("Distance from leftSide.: " + distX);
            //    if (crIsRunning)
            //    {
            //        StopCoroutine(MoveCardsInHand());
            //    }
            //}
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
            //if (transform.position.x < _myScroller.LeftSide.transform.position.x)
            //{
            //    distX = Math.Abs(_myScroller.LeftSide.transform.position.x - transform.position.x);
            //    print("Distance from leftSide.: " + distX);
            //    if (!crIsRunning)
            //    {
            //        goingRight = true;
            //        StartCoroutine(MoveCardsInHand());
            //    }
            //}
            //if (transform.position.x > _myScroller.RightSide.transform.position.x)
            //{
            //    distX = Math.Abs(_myScroller.LeftSide.transform.position.x - transform.position.x);
            //    print("Distance from leftSide.: " + distX);
            //    if (!crIsRunning)
            //    {
            //        goingRight = false;
            //        StartCoroutine(MoveCardsInHand());
            //    }
            //}
        }
        catch (System.Exception)
        {
            print("Could not Hover Over card - Not part of Hand");
        }
    }

    IEnumerator MoveCardsInHand()
    {
        crIsRunning = true;
        float x = distX;
        while (x > 0)
        {
            if (goingRight)
            {
                _myCardHolder.transform.position += new Vector3(0.01f,0);
                x -= 0.01f;
            }
            else
            {
                _myCardHolder.transform.position -= new Vector3(0.01f, 0);
                x += 0.01f;
            }
            yield return new WaitForSeconds(0.01f);
        }
        crIsRunning = false;
    }
}