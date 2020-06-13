using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
   [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject soundPlayer;
    float gameSpeed;
 [HideInInspector] public bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = FindObjectOfType<TimeScale>().GameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!gamePaused)
            {
                pauseMenu.SetActive(true); Debug.Log("Paused"); Time.timeScale = 0f; gamePaused = true;
                soundPlayer.GetComponent<AudioSource>().volume = 0.125f;
            }
            else
            {
                pauseMenu.SetActive(false); Debug.Log("Resumed"); Time.timeScale = gameSpeed; gamePaused = false;
                soundPlayer.GetComponent<AudioSource>().volume = 0.75f;
            }
        }
    }
}
