using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour
{
    #region Fields
    public GameObject cardPrefab;
    List<GameObject> _listOfCards;
    [SerializeField]
    private List<GameObject> deckOfCards;

    #endregion
    #region Properties
    public List<GameObject> DeckOfCards { get => deckOfCards; set => deckOfCards = value; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
        SetupCards();

        DealCards();
    }

    void SetupReferences()
    {
        _listOfCards = new List<GameObject>();
        DeckOfCards = new List<GameObject>();
    }

    public void DealCards()
    {
        ShuffleDeck();
        GiveCards();
    }

    private void SetupCards()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                string nameTemp = "card " + i + " " + j;
                GameObject newCard = Instantiate(cardPrefab, this.transform);
                newCard.transform.name = nameTemp;
                newCard.GetComponent<CardEditor>().SetupCard(i, j);
                newCard.GetComponent<CardEditor>().IsNotInPlay = false;

                _listOfCards.Add(newCard);
            }
        }
    }

    private void ShuffleDeck()
    {
        DeckOfCards.Clear();
        List<GameObject> _tempList = _listOfCards;
        int i;
        do
        {
            i = Random.Range(0, _tempList.Count);
            DeckOfCards.Add(_tempList[i]);
            _tempList.Remove(_tempList[i]);

        } while (DeckOfCards.Count < 52);
    }

    private void GiveCards()
    {
        GameObject temp = GameObject.Find("PlayerZone").gameObject;

        for (int i = 0; i < 26; i++)
        {
            temp.GetComponent<PlayerHand>().AddCardToPlayer(DeckOfCards[i]);
            DeckOfCards[i].GetComponent<CardEditor>().IsDealt = true;
            DeckOfCards[i].GetComponent<CardEditor>().IsNotInPlay = true;

            DeckOfCards[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            DeckOfCards[i].transform.SetParent(temp.GetComponent<PlayerHand>().CardOnboardPlace.transform);
            DeckOfCards.Remove(DeckOfCards[i]);
        }
    }
}