using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class devtool : MonoBehaviour
{
    SceneLoader sceneLoader;
    bool devtoolon = false;

    // Update is called once per frame
 public   void DevToolActivate()
    {
        DontDestroyOnLoad(gameObject);
        devtoolon = true;


        Debug.LogWarning("Unstable Developer Mode Activated- use with caution.");
        Debug.Log("N: Load next scene");
        Debug.Log("H: Plus one HP");
        Debug.Log("J: Activate Shop and make only 1 breakable block needed to win");
        Debug.Log("P: Lose the game");
    }

    private void Update()
    {
        if (devtoolon)
        {

            if (sceneLoader == null)
            {
                sceneLoader = FindObjectOfType<SceneLoader>();
            }

            DevTools();

        }

    }

    private void DevTools()
    {
        if (Input.GetKeyDown("n")) { sceneLoader.LoadNextScene(); }
        if (Input.GetKeyDown("h")) { FindObjectOfType<GameStatus>().plus1hp(); }
        if (Input.GetKeyDown("j")) { FindObjectOfType<Level>().Devtool(); }
        if (Input.GetKeyDown("p")) { SceneManager.LoadScene("Lose screen"); }
    }

    private void Start()
    {
     

    }



}
