using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : SingletonScript<PlayerScript>
{ 
    string _playerName;
    public int _inGamePointsCurrent;
    bool _isMyTurn;
    private int testCounter;

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
        TestCounter = 0;
        PlayerName = "Thomas";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
