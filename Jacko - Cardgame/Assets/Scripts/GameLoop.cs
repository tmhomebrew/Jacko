using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    #region Variables
    GameObject playerZoneOne, playerZoneTwo;
    private bool _playerOneJoined, _playerTwoJoined, _playersJoined;
    List<GameObject> _playersInGame;
    #endregion

    #region Properties
    public GameObject PlayerZoneOne { get => playerZoneOne; set => playerZoneOne = value; }
    public GameObject PlayerZoneTwo { get => playerZoneTwo; set => playerZoneTwo = value; }
    public bool PlayerOneJoined { get => _playerOneJoined; set => _playerOneJoined = value; }
    public bool PlayerTwoJoined { get => _playerTwoJoined; set => _playerTwoJoined = value; }

    #endregion

    private void Awake()
    {
        _playersInGame = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        foreach (Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.name.ToLower().Contains("playerzone"))
            {
                PlayerZoneOne = go.gameObject;
                print(playerZoneOne);
            }
            if (go.name.ToLower().Contains("playerzonetwo"))
            {
                PlayerZoneTwo = go.gameObject;
                print(playerZoneTwo);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
     /* Show Players
      * Show Deck
      * Shuffle Deck
      * Deal Cards to Players
      * Choose Starting player (Player with most spades, starts)
      */

        /* GAMELOOP
         * Show players available cards - Only 'one' type is available at a time (Spades, diamonds, clubs, hearts)
         * Show available cards, based on Cards in the "cardzone" and total value of cards in "Cardzone" <= 21..
         * --> If any available, Player select card/Play card (from available cards in "PlayerZone")
         * --> If non is available, player turn is ended, other players turn..
         * -----> If other player can't play more cards, end total.
         */
    }

    public void StartGame()
    {
        
    }

    public void OnPlayerJoin(GameObject player)
    {
        _playersInGame.Add(player);

        foreach (GameObject p in _playersInGame)
        {
            if (!PlayerOneJoined)
            {
                //This <-------------------------------------------------------------------------
            }
        }
    }
    //private void IsPlayersConnected()
    //{
    //    StartCoroutine(TryPlayersConnected());
    //}

    //IEnumerator TryPlayersConnected()
    //{
    //    _playersJoined = false;
    //    float sec = 0f;
    //    while (sec <= 10f)
    //    {
    //        //if both players are connected
    //        if (PlayerOneJoined && PlayerTwoJoined)
    //        {
    //            _playersJoined = true;
    //            break;
    //        }
    //        sec += Time.deltaTime;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    if (!_playersJoined)
    //    {
    //        print("Not enough players connected..");
    //    }
    //    else
    //    {
    //        print("Start game..");
    //    }
    //}
}