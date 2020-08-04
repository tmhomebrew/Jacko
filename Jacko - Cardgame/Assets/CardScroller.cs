using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScroller : MonoBehaviour
{
    public PlayerHand _myPlayerHand;
    [SerializeField]
    private GameObject leftSide, rightSide, mousePointer, _myCardHolder;

    IEnumerator cardsMoveFromLeftToRight;
    public bool temp;
    float distX;

    public GameObject LeftSide { get => leftSide; private set => leftSide = value; }
    public GameObject RightSide { get => rightSide; set => rightSide = value; }
    public float DistX { get => distX; set => distX = value; }

    // Start is called before the first frame update
    void Start()
    {
        distX = 5f;
        temp = false;
        if (_myPlayerHand == null)
        {
            _myPlayerHand = GetComponentInParent<PlayerHand>();
        }

        foreach (Transform t in transform.parent.GetComponentsInChildren<Transform>())
        {
            if (t.name.ToLower() == "cardholder")
            {
                _myCardHolder = t.gameObject;
                break;
            }
        }

        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.gameObject == null)
            {
                if (t.name.ToLower() == "left" && LeftSide == null)
                {
                    LeftSide = t.gameObject;
                    continue;
                }
                if (t.name.ToLower() == "right" && LeftSide == null)
                {
                    RightSide = t.gameObject;
                    continue;
                }
                if (t.name.ToLower() == "mousepointer" && mousePointer == null)
                {
                    mousePointer = t.gameObject;
                    continue;
                }
            }
        }
    }
}