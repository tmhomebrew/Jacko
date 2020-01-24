using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEditor : MonoBehaviour
{
    public Sprite _backgroundImage;
    public Sprite _foregroundImage;
    public Sprite _mainImage;
    [SerializeField]
    TMPro.TextMeshPro _topLeftStr, _botRightStr;
    [SerializeField]
    string cardName;
    Color _cardRed = Color.red;

    Animator myAnim;

    //Extern References
    CardTemplate myCard;

    public CardTemplate MyCard { get => myCard; set => myCard = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public Animator MyAnim { get => myAnim; set => myAnim = value; }

    void SetReferences()
    {
        MyAnim = GetComponent<Animator>();

        foreach (Transform go in GetComponentsInChildren<Transform>())
        {
            if (go.name == "BackgroundImage")
            {
                _backgroundImage = go.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "ForegroundImage")
            {
                _foregroundImage = go.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "CardImage")
            {
                _mainImage = go.GetComponent<SpriteRenderer>().sprite;
            }
            if (go.name == "TopLeft")
            {
                _topLeftStr = go.GetComponentInChildren<TMPro.TextMeshPro>();
            }
            if (go.name == "BotRight")
            {
                _botRightStr = go.GetComponentInChildren<TMPro.TextMeshPro>();
            }
        }
    }

    public void SetupCard(int type, int number)
    {
        MyCard = new CardTemplate(type, number);
        SetReferences(); //For visual feedback in the Inspector..

        //TopLeft TextBox fill
        _topLeftStr.text = MyCard.CardValueStr;
        _topLeftStr.text += MyCard.CardTypeStr;
        CardName = MyCard.CardTypeStr + MyCard.CardValueStr;

        //BotRight TextBox fill
        _botRightStr.text = MyCard.CardValueStr;
        _botRightStr.text += MyCard.CardTypeStr;

        if (type == 1 || type == 3)
        {
            _topLeftStr.color = _cardRed;
            _botRightStr.color = _cardRed;
        }
    }
}
