using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject _inGameMenu, _greyGO, _gameBoard;
    private Image _greyImage;

    private void Start()
    {
        _greyImage = _greyGO.GetComponent<Image>();
    }

    public void ShowMenu()
    {
        _inGameMenu.SetActive(true);
        _greyImage.enabled = true;
        _gameBoard.SetActive(false);
    }

    public void DisableMenu()
    {
        _inGameMenu.SetActive(false);
        _greyImage.enabled = false;
        _gameBoard.SetActive(true);
    }

    public void ReturnToTitel()
    {
        _inGameMenu.SetActive(false);
        print("Going from GameScreen to TitelScreen..");
        Loader.Load(Loader.Scene.TitelScreen);
    }
}
