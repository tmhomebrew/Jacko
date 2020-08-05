using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    #region Field
    [SerializeField]
    List<GameObject> _cardsInHand;
    List<GameObject> tempCardsToHand = new List<GameObject>();
    GameObject _cardOnboardPlace;
    [SerializeField]
    GameObject _preSelectedCard;
    private float _cardDistance = 0.5f;

    //References
    [SerializeField]
    GameObject _cardZone;
    GameObject _boardZone;

    #endregion
    #region Properties
    public List<GameObject> CardsInHand { get => _cardsInHand; set => _cardsInHand = value; }
    public GameObject CardOnboardPlace { get => _cardOnboardPlace; set => _cardOnboardPlace = value; }
    public GameObject CardZone { get => _cardZone; set => _cardZone = value; }
    public GameObject PreSelectedCard { get => _preSelectedCard; private set => _preSelectedCard = value; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        CardsInHand = new List<GameObject>();
        CardZone = GameObject.FindGameObjectWithTag("CardZone").gameObject;
        _boardZone = FindObjectOfType<BoardController>().gameObject;

        foreach (Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.name.ToLower().Contains("cardholder"))
            {
                CardOnboardPlace = go.gameObject;
            }
        }
    }

    public void AddCardToPlayer(GameObject cardToAdd)
    {
        CardsInHand.Add(cardToAdd);
        SortHand();
    }

    public void CardHolder()
    {
        float i = (_cardDistance / 2f);
        CardOnboardPlace.transform.position = new Vector3(-CardsInHand.Count * i, transform.position.y, transform.position.z);
        
        #region Old Version of holding Cards in hand..
        //foreach (GameObject card in CardsInHand)
        //{
        //    card.transform.position = new Vector3(
        //        CardOnboardPlace.transform.position.x + i,
        //        CardOnboardPlace.transform.position.y, 
        //        -2 + (-i/4));
        //    i = _cardDistance + i;
        //}
        #endregion
        #region New Version - Better placement for last cards..
        foreach (GameObject card in CardsInHand)
        {
            if (CardsInHand.Count > 1)
            {
                card.transform.position = new Vector3(
                    CardOnboardPlace.transform.position.x + i,
                    CardOnboardPlace.transform.position.y,
                    -2 + (-i / 4));
                i += _cardDistance;
            }
            else
            {
                card.transform.position = new Vector3(
                    0f,
                    CardOnboardPlace.transform.position.y,
                    -2 + (-i / 4));
            }
        }
        #endregion
    }

    void SortHand()
    {
        tempCardsToHand = CardsInHand;

        tempCardsToHand = tempCardsToHand.OrderBy(o => o.transform.GetComponent<CardEditor>().MyCard.CardValueInt).ToList();
        tempCardsToHand = tempCardsToHand.OrderByDescending(o => o.transform.GetComponent<CardEditor>().MyCard.CardTypeInt).ToList();
        CardsInHand.Clear();
        CardsInHand = tempCardsToHand;
        CardHolder();
    }

    public void SelectCard(GameObject cardSelected)
    {
        if (PreSelectedCard != null)
        {
            if (PreSelectedCard == cardSelected)
            {
                //if (IsPlayersTurn == true)
                {
                    PlayCard(cardSelected); //Plays the card, if the card is already selected.. "Double Click"..
                }
            }
            else
            {
                //print("Previous selected card is.: " + _preSelectedCard.transform.GetComponent<CardEditor>().CardName);
                DeSelectedCard();
                PreSelectedCard = cardSelected;
                //print("New Previous Card selected is.: " + _preSelectedCard.transform.GetComponent<CardEditor>().CardName);
                PreSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", true);
            }
        }
        else
        {
            //print("Card selected is.: " + cardSelected.transform.GetComponent<CardEditor>().CardName);
            PreSelectedCard = cardSelected;
            PreSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", true);
            //print("A card has been selected.");
        }
    }

    private void DeSelectedCard()
    {
        PreSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", false);
        //_preSelectedCard.transform.position += new Vector3(0, -0.6f);
        PreSelectedCard = null;
    }

    public void HoverOverCard(GameObject card)
    {
        //print(card.transform.name + " is hovering.!");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("MouseOver", true);
    }

    public void HoverOverCancel(GameObject card)
    {
        //print(card.transform.name + " is lowering.!");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("MouseOver", false);
    }

    public void PlayCard(GameObject card)
    {
        //print(card.transform.GetComponent<CardEditor>().CardName + " has been played....");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsPlayed", true);
        
        CardsInHand.Remove(card);
        _boardZone.GetComponent<BoardController>().CardFromHandToPlayedCardsPile(card);
        SortHand();
    }

    private void OnMouseDown()
    {
        print("Im here");
        if (PreSelectedCard != null)
        {
            DeSelectedCard();
        }
    }
}