using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadR : MonoBehaviour
{
 
       

    

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameStatus>() !=  null)
        {
            FindObjectOfType<GameStatus>().findscoreandhp();
            Destroy(gameObject, 1f);
        }
    }

    public void ChooChoo() { DontDestroyOnLoad(gameObject); if (PlayerPrefs.GetInt("Difficulty") != 0) { FindObjectOfType<Difficulty>().easyMode = true; } else { FindObjectOfType<Difficulty>().easyMode = false; } }


}
