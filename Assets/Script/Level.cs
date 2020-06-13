using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] bool AutoSkip = false;
    [SerializeField] bool noNextLevel = false;
    [SerializeField] int breakalbleBlocks; //serialised for degugging purposes
    [SerializeField] public bool shopopen = false; 
    //cached reference
    SceneLoader sceneLoader;
 [SerializeField]   Button button;
    [SerializeField] Button Shop;
public void CountBreakableBlocks()
    {


        breakalbleBlocks++;



    }


    public void BlockDestroyed()
    {

        breakalbleBlocks--;
         if (breakalbleBlocks <= 0) {

            Ball ball = FindObjectOfType<Ball>();
            ball.Win();

            if (breakalbleBlocks <= 0 && AutoSkip == true)
            {
                if (!noNextLevel)
                {
                    sceneLoader.LoadNextScene();
                }
                else
                {
                   
                    PortalToVictory();
                }
            }
            else if (breakalbleBlocks <= 0 && !noNextLevel)
            {

                button.gameObject.SetActive(true);
                if (shopopen == true) { Shop.gameObject.SetActive(true); }


            }
        }
        
    }

    private void PortalToVictory()
    {
        FindObjectOfType<CreditLoader>().Work();
    }


    public void Start()
    {
       sceneLoader = FindObjectOfType<SceneLoader>();
      if(  FindObjectOfType<GameStatus>().PermanantAutoskip == true) { AutoSkip = true; }
        FindObjectOfType<GameStatus>().startedYet = true;
    }

    public void Devtool() { breakalbleBlocks = 1;
        shopopen = true;
    }

    private void Awake()
    {
        FindObjectOfType<Difficulty>().StartThisOne();
    }




}
