using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config perams
 [SerializeField] AudioClip AudioForBlock;
   
    [SerializeField] Sprite[] hitsprite;
    [SerializeField] bool Gold = false;
    [SerializeField] int extraDamage = 0;
    // cached reference
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit; //SF for debug

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable" || tag == "Urainium")
        {
            HandleHits();
        }

        if (tag == "Deadly") { FindObjectOfType<LoseCollider>().ForceInjure(extraDamage,false); }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Gas") { HandleHits(); }
    }

    private void HandleHits()
    {
        int MaxHits = hitsprite.Length + 1;
        timesHit++;
     
        if (timesHit >= MaxHits)
        {
            if (Gold == true) { gold(); }
            DestroyBlock();
        }
        else
        {
            ChangeDamageSprite();


        }
    }

    private void gold()
    {
        FindObjectOfType<GameStatus>().gold();
    }

    private void ChangeDamageSprite()
    {
        int SpriteIndex = timesHit - 1;
        if (hitsprite[SpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsprite[SpriteIndex];
        }
        else
        {
            string name = gameObject.name;
            Debug.LogError("Block sprite ("+name+") is missing from array!");
        }
    
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(AudioForBlock, Camera.main.transform.position);
        Destroy(gameObject, 0.0f);
        if (tag == "Breakable" || tag == "Gas") { level.BlockDestroyed(); }
       
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.AddToScore();
        if (tag == "Urainium") { gameStatus.plus1hp(); }
    }

    private void Start()
    { if (tag == "Breakable" ||tag == "Gas")
        {
            level = FindObjectOfType<Level>();
            level.CountBreakableBlocks();
        }
        FindObjectOfType<GameStatus>().resetgold();


    }


}
