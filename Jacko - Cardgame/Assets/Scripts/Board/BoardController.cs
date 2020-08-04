using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    BoardController _boardRef;

    private void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        _boardRef = GetComponent<BoardController>();
    }


}

public class BoardController : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject _cardZone, _deckZone, _discardZone;
    List<GameObject> _discardPileList, _playedCardPile;

    float _sortingVal;

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
    
    /// <summary>
    /// Cards in CardZone. When there are cards in play, they are sorted from bottom and up.
    /// </summary>
    void SortCardsPlayed()
    {
        if (_playedCardPile.Count > 0)
        {
            _sortingVal = 0;
            foreach (GameObject card in _playedCardPile)
            {
                _sortingVal -= 0.05f;
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
            _playedCardPile.Add(card);
            foreach (Transform t in CardZone.GetComponentInChildren<Transform>())
            {
                if (t.name.ToLower().Contains("cardholder"))
                {
                    card.transform.parent = t;
                    break;
                }
            }
            card.transform.GetComponent<Animator>().enabled = false;
            StartCoroutine(MoveCard(card));
        }
        catch (System.Exception)
        {
            print("Debug..: Could not play card and add Card to _playedCardPile<>..");
            GameObject go = GameObject.FindGameObjectWithTag("PlayerZone").GetComponent<Transform>().gameObject;
            go.GetComponent<PlayerHand>().AddCardToPlayer(card);
        }
    }

    //Animation of a card, playerd from hand
    IEnumerator MoveCard(GameObject card)
    {
        Vector3 moveToThis;
        float step = 0;
        moveToThis = CardZone.transform.position + new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), -3);
        while (Vector3.Distance(card.transform.position, moveToThis) > 0.1f)
        {
            step += 0.1f * Time.deltaTime;
            card.transform.position = Vector3.MoveTowards(card.transform.position, moveToThis, step);
            yield return null;
        }
        SortCardsPlayed();
    }
}