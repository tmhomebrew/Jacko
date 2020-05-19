using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            try
            {
                if (GameObject.FindGameObjectWithTag("Player").activeSelf)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().TestCounter++;
                }
            }
            catch (System.Exception)
            {
                print("Could not find player");
                throw;
            }
        }
    }
}
