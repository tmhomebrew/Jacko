using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}