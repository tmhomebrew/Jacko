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
    GameObject _cardOnboardPlace;

    //References
    [SerializeField]
    GameObject _cardZone;
    GameObject _boardZone;

    #endregion
    #region Properties
    public List<GameObject> CardsInHand { get => _cardsInHand; set => _cardsInHand = value; }
    public GameObject CardOnboardPlace { get => _cardOnboardPlace; set => _cardOnboardPlace = value; }
    public GameObject CardZone { get => _cardZone; set => _cardZone = value; }

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
        if (CardsInHand.Count == 26)
        {
            SortHand();
        }
    }

    float _cardDistance = 0.5f;

    public void CardHolder()
    {
        float i = 0f;
        CardOnboardPlace.transform.position = new Vector3( -CardsInHand.Count / 4, transform.position.y, transform.position.z);
        foreach (GameObject card in CardsInHand)
        {
            card.transform.position = new Vector3(CardOnboardPlace.transform.position.x + i, CardOnboardPlace.transform.position.y, -i/4);
            i = _cardDistance + i;
        }
    }

    List<GameObject> tempCardsToHand = new List<GameObject>();
    void SortHand()
    {
        tempCardsToHand = CardsInHand;

        tempCardsToHand = tempCardsToHand.OrderBy(o => o.transform.GetComponent<CardEditor>().MyCard.CardValueInt).ToList();
        tempCardsToHand = tempCardsToHand.OrderByDescending(o => o.transform.GetComponent<CardEditor>().MyCard.CardTypeInt).ToList();
        CardsInHand.Clear();
        CardsInHand = tempCardsToHand;
        CardHolder();
    }

    [SerializeField]
    GameObject _preSelectedCard;
    public void SelectCard(GameObject cardSelected)
    {
        if (_preSelectedCard != null)
        {
            if (_preSelectedCard == cardSelected)
            {
                //if (IsPlayersTurn == true)
                {
                    PlayCard(cardSelected); //Plays the card double clicked..
                }
            }
            else
            {
                print("Previous selected card is.: " + _preSelectedCard.transform.GetComponent<CardEditor>().CardName);
                DeSelectedCard();
                _preSelectedCard = cardSelected;
                print("New Previous Card selected is.: " + _preSelectedCard.transform.GetComponent<CardEditor>().CardName);
                _preSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", true);
            }
        }
        else
        {
            print("Card selected is.: " + cardSelected.transform.GetComponent<CardEditor>().CardName);
            _preSelectedCard = cardSelected;
            _preSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", true);
            print("A card has been selected.");
        }
    }

    public void DeSelectedCard()
    {
        _preSelectedCard.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsSelected", false);
        _preSelectedCard = null;
    }

    public void HoverOverCard(GameObject card)
    {
        print(card.transform.name + " is hovering.!");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("MouseOver", true);
    }

    public void HoverOverCancel(GameObject card)
    {
        print(card.transform.name + " is lowering.!");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("MouseOver", false);
    }

    public void PlayCard(GameObject card)
    {
        print(card.transform.GetComponent<CardEditor>().CardName + " has been played....");
        card.transform.GetComponent<CardEditor>().MyAnim.SetBool("IsPlayed", true);
        

        CardsInHand.Remove(card);
        _boardZone.GetComponent<BoardController>().CardFromHandToPlayedCardsPile(card);
        SortHand();
        //CardHolder(); //<--- Update Current Hand list, to show a new hand..
    }
}