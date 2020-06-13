using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Workshopfunctionallity : MonoBehaviour
{
    //config perams
    [SerializeField] News [] news;
    [SerializeField] TextMeshProUGUI MsgBox;
    [SerializeField] TextMeshProUGUI TitleNews;
    [SerializeField] TextMeshProUGUI DescNews;
    
    //cached references
    GameStatus gameStatus;

    //State variables
    int itemcost = 1000;
    string item = "null";
    bool failiure = false;
    bool sucsess = false;
    float timer;
    bool HasNewsBeenFound = false;
    int pinpointer;
    int currentScene;
    int nextScene;
   [SerializeField] int potentialpinpoint; //serialised for debug
    [SerializeField]  int potentialpinpointstep1; //serialised for debug
    public int length; //serialised for debug

    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        if (FindObjectOfType<Difficulty>()) { FindObjectOfType<Difficulty>().ClearLVL(); }

         nextScene = gameStatus.nextscene;
         currentScene = nextScene - 1;

        if (currentScene == 1) { pinpointer = 0; }
        if (currentScene != 1) { ArrayLogic(); }
        pasteintodescription();


       // length = news.Length;

      //  DescNews.text = news[nextScene-1].ReturnText();
     //   TitleNews.text = "Levels:" + (nextScene-1) + "-" + (nextScene+4);
    }

    private void pasteintodescription()
    {
        DescNews.text = news[pinpointer].ReturnText();
           TitleNews.text = "Levels:" + (currentScene-1) + "-" + ((currentScene-1) + 4);
    }


    private void ArrayLogic()
    {
        pinpointer = (currentScene - 1) / 5;

    }

    public void BonusHeart()
    {
        itemcost = 1000;
        item = "BonusHeart";
        ConfirmOrder();

    }

    public void PermHeart()
    {
        itemcost = 2000;
        item = "PermHeart";
        ConfirmOrder();

    }

    public void Save()
    {
        itemcost = 3000;
        item = "Save";
        ConfirmOrder();

    }

    //purchase item
    public void ConfirmOrder()
    {
        bool Cashier = gameStatus.Cashier(itemcost);
        if (Cashier) { gameStatus.ATM(itemcost,item);sucsess = true; timer = 1.5f; }
        else { OrderFailed(); }

    }
    
    void OrderFailed()
    {
        failiure = true;
        timer = 1.5f;
    }

    private void Update()
    {
        if (failiure) {
            timer -= Time.deltaTime;
            MsgBox.color = Color.red;
            MsgBox.text = "Cant Afford!";
            if(timer <= 0) { failiure = false; Defaultmsg(); }

        }
        if (sucsess)
        {
            timer -= Time.deltaTime;
            MsgBox.color = Color.green;
            MsgBox.text = "Sucsess!";
            if (timer <= 0) { sucsess = false; Defaultmsg(); }

        }
    }

    private void Defaultmsg()
    {
        MsgBox.color = Color.black;
        MsgBox.text = "Buy      Balls!";
    }

    public void exit()
    {
        gameStatus.startedYet = false;
        SceneManager.LoadScene(nextScene);

    }

}
