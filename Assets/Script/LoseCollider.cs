using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.Injury(0);

        if (gameStatus.HowManyLivesAreThere() <= 0)
        {
            SceneManager.LoadScene("Lose screen");
        }
        else {
            FindObjectOfType<Ball>().ReGround();
            gameStatus.hPUpdate();




        }
    }
    public void ForceInjure(int extradamage, bool instaKill)
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.Injury(extradamage);

        if (gameStatus.HowManyLivesAreThere() <= 0 || instaKill)
        {
            SceneManager.LoadScene("Lose screen");
        }
        else
        {
            FindObjectOfType<Ball>().ReGround();
            gameStatus.hPUpdate();
        }
       

    }
    
}
