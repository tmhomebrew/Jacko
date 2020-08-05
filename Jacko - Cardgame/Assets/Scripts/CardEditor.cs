using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEditor : MonoBehaviour
{
    #region Fields
    public Sprite _backgroundImage, _foregroundImage, _mainImage;
    [SerializeField]
    TMPro.TextMeshPro _topLeftStr, _botRightStr;
    [SerializeField]
    string cardName;
    Color _cardRed = Color.red;
    [SerializeField]
    bool isDealt, isNotInPlay;
    GameObject _myCardInfo;
    Animator myAnim;

    //Extern References
    CardTemplate myCard;

    #endregion
    #region Properties
    public CardTemplate MyCard { get => myCard; private set => myCard = value; }
    public string CardName { get => cardName; private set => cardName = value; }
    public Animator MyAnim { get => myAnim; private set => myAnim = value; }
    public bool IsDealt { get => isDealt; set => isDealt = value; }
    public bool IsNotInPlay
    {
        get => isNotInPlay; 
        set
        {
            isNotInPlay = value;
            if (!isNotInPlay)
            {
                _myCardInfo.SetActive(false);
            }
            else
            {
                _myCardInfo.SetActive(true);
            }
        }
    }

    #endregion

    void SetReferences()
    {
        MyAnim = GetComponent<Animator>();
        IsDealt = false;

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
            if (go.name == "InfoHolder")
            {
                _myCardInfo = go.gameObject;
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