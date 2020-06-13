using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour

{
    static bool loadscenecheck;
    GameStatus gameStatus;
    int cachedscore, cachedhealth;
    bool areWeInGame = false;
    float startuptimer = 1f;



    public void LoadNextScene()
    {
        if (FindObjectsOfType<GameStatus>().Length > 0)
        {
            FindObjectOfType<GameStatus>().ByeByeBonusLives();
            FindObjectOfType<GameStatus>().Livebegin();

        }

     
        
        


        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);

        




    }
    public void restart()
    {
        if (gameStatus != null)
        {
            gameStatus.suicide();
        }

        if (FindObjectOfType<Difficulty>()) { FindObjectOfType<Difficulty>().ClearLVL(); }

        SceneManager.LoadScene(0);
       
        
    }



    private void Start()
    {
     if  ( FindObjectOfType<GameStatus>() != null) { gameStatus = FindObjectOfType<GameStatus>(); }



        string CurrentSceneIndexstringy = SceneManager.GetActiveScene().name;
        if (CurrentSceneIndexstringy == "Lose screen" || CurrentSceneIndexstringy == "End Credits")
        {
            GameStatus gameStatus = FindObjectOfType<GameStatus>();
            Destroy(gameStatus.gameObject);

        }

    }

    public void GoToTheWorkshop()
    {
        SceneManager.LoadScene("Workshop");
        FindObjectOfType<GameStatus>().Livebegin();
    }


    public void load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("NextLevel"));
        
    }


    public void resetsave()
    {
        PlayerPrefs.DeleteAll();

    }

    public void Reload()
    { if (areWeInGame) { gameStatus.score = cachedscore; gameStatus.currentLives = cachedhealth; }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    { if (startuptimer > 0)
        {
            startuptimer -= Time.deltaTime;
        }
    else if (!areWeInGame && gameStatus != null && startuptimer <= 0)
           
           {
             
                cachedhealth = gameStatus.currentLives;
                cachedscore = gameStatus.score;
                areWeInGame = true;
            }
    }


    public IEnumerator StaggeredLoadNextScene()
    {
        yield return new WaitForEndOfFrame();
        LoadNextScene();
    }

    public void StaggeredLoadScene()
    {
        StartCoroutine(StaggeredLoadNextScene());
    }

    public void UpadeEasyMode(bool yN)
    {
        if (yN) { FindObjectOfType<Difficulty>().easyMode = true; }
        else { FindObjectOfType<Difficulty>().easyMode = false; }
    }


}



