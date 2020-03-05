using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    #region Fields
    public GameObject _playerLoggedGO, _menuGO, _backGroundGO;
    public GameObject _signIn, _signOut, _playJacko;
    string _textForLogin = "Logged as.: ";

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        SetupReferences();
    }

    void SetupReferences()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.name.ToLower().Contains("backgroundimage"))
            {
                _backGroundGO = t.GetComponent<Transform>().gameObject;
                continue;
            }
            if (t.name.ToLower().Contains("menu"))
            {
                _menuGO = t.GetComponent<Transform>().gameObject;
                continue;
            }
            if (t.name.ToLower().Contains("playerlogged"))
            {
                _playerLoggedGO = t.GetComponent<Transform>().gameObject;
                continue;
            }
            if (t.name.ToLower().Contains("signin"))
            {
                _signIn = t.GetComponent<Transform>().gameObject;
                continue;
            }
            if (t.name.ToLower().Contains("signout"))
            {
                _signOut = t.GetComponent<Transform>().gameObject;
                continue;
            }
            if (t.name.ToLower().Contains("playjacko"))
            {
                _playJacko = t.GetComponent<Transform>().gameObject;
                continue;
            }
        }

        SetLoggedInText();
        SetBools(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLoggedInText(string name)
    {
        if (name != null)
        {
            _playerLoggedGO.GetComponentInChildren<Text>().text = _textForLogin + name;
        }
    }
    void SetLoggedInText()
    {
        _playerLoggedGO.GetComponentInChildren<Text>().text = "";
    }

    public void SignIn()
    {
        SetBools(false);
        SetLoggedInText("Master Blaster"); //<-- Google ID
    }

    public void SignOut()
    {
        SetBools(true);
        SetLoggedInText();
    }

    void SetBools(bool isActive)
    {
        _signIn.SetActive(isActive);
        _signOut.SetActive(!isActive);
        _playJacko.SetActive(!isActive);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
