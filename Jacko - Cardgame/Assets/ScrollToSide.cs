using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollToSide : MonoBehaviour
{
    [SerializeField]
    private GameObject _myCardHolder;
    [SerializeField]
    private bool rightSide, crIsRunning;
    float tempValue;

    IEnumerator cardsToMove;

    public bool RightSide { get => rightSide; private set => rightSide = value; }

    // Start is called before the first frame update
    void Start()
    {
        crIsRunning = false;
        //cardsToMove = MoveCardsInHand();

        foreach (Transform t in transform.parent.parent.GetComponentsInChildren<Transform>())
        {
            if (t.name.ToLower() == "cardholder")
            {
                _myCardHolder = t.gameObject;
                break;
            }
        }

        if (transform.name.ToLower() == "left")
        {
            RightSide = false;
        }
        else
        {
            RightSide = true;
        }
    }

    private void OnMouseOver()
    {
        if (RightSide)
        {
            if (tempValue > 0)
            //if (GetComponentInParent<CardScroller>().DistX > _myCardHolder.transform.position.x)
            {
                _myCardHolder.transform.position -= new Vector3(1f, 0) * Time.deltaTime;
                tempValue -= 0.1f;
                print(tempValue);
            }
        }
        else
        {
            if (tempValue < 0)
            {
                _myCardHolder.transform.position += new Vector3(1f, 0) * Time.deltaTime;
                tempValue += 0.1f;
                print(tempValue);
            }
        }
        //if (!crIsRunning)
        //{
        //    StartCoroutine(cardsToMove);
        //}
    }

    private void OnMouseEnter()
    {
        if (RightSide)
        {
            print("Right side is moving.");
            tempValue = Math.Abs(_myCardHolder.transform.position.x);
        }
        else
        {
            print("Left side is moving.");
            tempValue = _myCardHolder.transform.position.x;
        }
        print("Entered a scroll-area..: " + tempValue);
        //StartCoroutine(cardsToMove);
    }

    private void OnMouseExit()
    {
        if (RightSide)
        {
            print("Right side has stopped.");
        }
        else
        {
            print("Left side has stopped.");
        }
        //StopCoroutine(cardsToMove);
        //crIsRunning = false;
    }

    //IEnumerator MoveCardsInHand()
    //{
    //    crIsRunning = true;
    //    //while (x > 0)
    //    //{
    //    if (RightSide)
    //    {
    //        while (distX > 0)
    //        {
    //            _myCardHolder.transform.position += new Vector3(0.01f, 0);
    //            distX -= 0.01f;
    //            yield return new WaitForSeconds(0.01f);
    //        }
    //    }
    //    else
    //    {
    //        while (distX < 0)
    //        {
    //            _myCardHolder.transform.position -= new Vector3(0.01f, 0);
    //            distX += 0.01f;
    //            yield return new WaitForSeconds(0.01f);
    //        }
    //    }
    //    //}
    //    crIsRunning = false;
    //}
}
