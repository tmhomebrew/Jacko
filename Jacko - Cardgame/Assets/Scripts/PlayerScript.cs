using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour /*SingletonScript<PlayerScript>*/
{ 
    //Generel Information
    string _playerName;
    
    //Test
    public int _inGamePointsCurrent;
    private int testCounter;

    //In-Game Variables
    bool _isMyTurn;


    public int TestCounter
    {
        get => testCounter; set
        {
            testCounter = value;
            _inGamePointsCurrent = testCounter;
        }
    }
    public string PlayerName { get => _playerName; set => _playerName = value; }

    // Start is called before the first frame update
    void Start()
    {
        SetupVariables();
        PlayerName = "NotGoogleSignIn - Thomas";
    }

    void SetupVariables()
    {
        _isMyTurn = false;


        //For Test only
#if UNITY_EDITOR
        TestCounter = 0;
#else

#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
