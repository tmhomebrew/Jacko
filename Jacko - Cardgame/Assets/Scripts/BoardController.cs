using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject _cardZone, _deckZone, _discardZone;

    List<GameObject> _discardPileList, _playedCardPile;

    #endregion
    #region Properties
    public GameObject CardZone { get => _cardZone; set => _cardZone = value; }
    public GameObject DeckZone { get => _deckZone; set => _deckZone = value; }
    public GameObject DiscardZone { get => _discardZone; set => _discardZone = value; }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        _discardPileList = new List<GameObject>();
        _playedCardPile = new List<GameObject>();

        foreach (Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.tag.ToLower() == "cardzone")
            {
                CardZone = go.gameObject;
                continue;
            }
            if (go.tag.ToLower() == "deckzone")
            {
                DeckZone = go.gameObject;
                continue;
            }
            if (go.tag.ToLower() == "discardzone")
            {
                DiscardZone = go.gameObject;
                continue;
            }
        }
    }

    void PlayedCardsToDiscardPile()
    {
        try
        {
            foreach (GameObject card in _playedCardPile)
            {
                _discardPileList.Add(card);
            }
            _playedCardPile.Clear();
        }
        catch (System.Exception)
        {
            print("Debug..: No Cards found in _playedCards, to add to the _discardPile..");
        }
    }


    void SortCardsPlayed()
    {
        if (_playedCardPile.Count > 0)
        {
            _sortingVal = 0;
            foreach (GameObject card in _playedCardPile)
            {
                _sortingVal -= 0.01f;
                card.transform.position = new Vector3(
                    card.transform.position.x,
                    card.transform.position.y,
                    0 + _sortingVal);
            }
        }
    }

    void DiscardPileToDeckPile()
    {
        try
        {
            //foreach (GameObject card in _discardPileList)
            //{
            //    DeckZone.GetComponentInChildren<DeckHandler>().DeckOfCards.Add(card);
            //}
            _discardPileList.Clear();
        }
        catch (System.Exception)
        {
            print("Debug..: No Cards found in _discardPile, to add to the _deckPile..");
        }
    }

    public void CardFromHandToPlayedCardsPile(GameObject card)
    {
        try
        {
            if (_playedCardPile.Count >= 26)
            {
                _sortingVal = 0;
            }
            else
            {
                _sortingVal += 0.01f;
            }
            _playedCardPile.Add(card);
            card.transform.parent = CardZone.transform;
            card.transform.GetComponent<Animator>().enabled = false;
            StartCoroutine(MoveCard(card));
            //if (card.transform.position != CardZone.transform.position)
            //{
            //    print("Moving card from Hand to PlayedCardPile..");
            //    //card.transform.Translate(CardZone.transform.position);
            //    card.transform.position = Vector3.MoveTowards(card.transform.position, CardZone.transform.position, step);
            //}
        }
        catch (System.Exception)
        {
            print("Debug..: Could not play Card..");
        }
    }

    float step = 0, _sortingVal;
    IEnumerator MoveCard(GameObject card)
    {
        _sortingVal = 0;
        while(Vector3.Distance(card.transform.position, CardZone.transform.position) > 0.1f)
        {
            step += 0.1f * Time.deltaTime;
            print("Moving card from Hand to PlayedCardPile..");
            card.transform.position = Vector3.MoveTowards(card.transform.position, CardZone.transform.position, step);
            
            yield return null;
        }
        card.transform.position = new Vector3(
           card.transform.position.x,
           card.transform.position.y,
           0 + _sortingVal);
        //Changes..
        step = 0;
        SortCardsPlayed();
    }
}