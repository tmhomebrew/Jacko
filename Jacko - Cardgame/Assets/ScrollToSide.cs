using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollToSide : MonoBehaviour
{
    #region Values
    [SerializeField]
    private GameObject _myCardHolder;
    [SerializeField]
    private bool rightSide;
    [SerializeField]
    static float scrollValue;
    public int minmaxValue;

    #endregion
    #region Properties
    public bool RightSide { get => rightSide; private set => rightSide = value; }
    public float ScrollValue
    {
        get { return scrollValue; }
        set
        {
            if (value <= (minmaxValue * -1))
            {
                scrollValue = (minmaxValue * -1);
            }
            else if (value >= minmaxValue)
            {
                scrollValue = minmaxValue;
            }
            else
            {
                scrollValue = value;
            }
        }
    }

    #endregion

    private void Awake()
    {
        minmaxValue = 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScrollValue = 0f;

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
            if (ScrollValue > (minmaxValue * -1))
            {
                _myCardHolder.transform.position -= new Vector3(2f, 0) * Time.deltaTime;
                ScrollValue -= 0.1f;
                print(ScrollValue);
            }
        }
        else
        {
            if (ScrollValue < minmaxValue)
            {
                _myCardHolder.transform.position += new Vector3(2f, 0) * Time.deltaTime;
                ScrollValue += 0.1f;
                print(ScrollValue);
            }
        }
    }

    #region Debug with Mouse-Enter/-Exit
    //private void OnMouseEnter()
    //{
    //    if (RightSide)
    //    {
    //        print("Right side is moving.");
    //    }
    //    else
    //    {
    //        print("Left side is moving.");
    //    }
    //    print("Entered a scroll-area..: " + TempValue);
    //}

    //private void OnMouseExit()
    //{
    //    if (RightSide)
    //    {
    //        print("Right side has stopped.");
    //    }
    //    else
    //    {
    //        print("Left side has stopped.");
    //    }
    //}
    #endregion
}
