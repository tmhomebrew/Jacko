using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardTemplate
{
    #region Fields
    int _cardValueInt, _cardTypeInt;
    string _cardValueStr, _cardTypeStr;

    #endregion
    #region Properties
    public int CardTypeInt { get => _cardTypeInt; private set => _cardTypeInt = value; }
    public int CardValueInt { get => _cardValueInt; private set => _cardValueInt = value; }
    public string CardValueStr { get => _cardValueStr; private set => _cardValueStr = value; }
    public string CardTypeStr { get => _cardTypeStr; private set => _cardTypeStr = value; }

    #endregion

    public CardTemplate(int ct, int value)
    {
        CardTypeStr = TypeOfCard(ct);
        CardTypeInt = ct;
        
        CardValueStr = ValueOfCard(value);
        CardValueInt = value;
    }

    string ValueOfCard(int value)
    {
        string x = "";

        if (value >= 2 && value <= 10)
        {
            x = value.ToString();
        }
        else if (value == 11)
        {
            x = "J";
        }
        else if (value == 12)
        {
            x = "Q";
        }
        else if (value == 13)
        {
            x = "K";
        }
        else if (value == 1)
        {
            x = "A";
        }

        return x;
    }

    string TypeOfCard(int type)
    {
        string x = "";
        switch (type)
        {
            case 0:
                x = "s";
                break;
            case 1:
                x = "h";
                break;
            case 2:
                x = "c";
                break;
            case 3:
                x = "d";
                break;
        }
        return x;
    }
}
