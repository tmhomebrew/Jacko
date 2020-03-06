using System;
using System.Collections;
using UnityEngine.SceneManagement;

public static class Loader
{
    //public static SceneControllerScript Instance;

    public enum Scene
    {
        LoadingScreen,
        TilelScreen,
        GameScreen
    }

    private static Action onLoaderCallBack;

    public static void Load(Scene scene)
    {
        //Set the loader callback action to load the target scene
        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        //Load the loading scene
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallBack()
    {
        //Triggered after the first Update which lets the screen refresh
        //Execute the loader callback action which will load the target scene
        if (onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }
}
