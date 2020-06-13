using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{

    //config perams

    [SerializeField]public int score = 0;
    [SerializeField] int pointsperblockdestroyed = 80;
    [SerializeField] int paddlelessscoremultiplier = 0;
    [SerializeField] int paddlelessscoredefault = 30;
    [SerializeField] bool Autoplay;
    [SerializeField] public bool PermanantAutoskip;
    [SerializeField]public int startingLives = 3;
    

    //cached references
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI textHP;
    ShopDisplayer shopDisplayer;

    //state variables
 public   int currentLives = 0;
    int bonusLives = 0;
    public bool startedYet = false;

    //shop variables
  public  int nextscene;

    private void Awake()
    {
    
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }



    void Update()
    {
        if (shopDisplayer == null) { shopDisplayer = FindObjectOfType<ShopDisplayer>(); }
        if(SceneManager.GetActiveScene().name == "Workshop" && shopDisplayer != null) {
            shopDisplayer.Updater(currentLives,score);
        }
        text.text = score.ToString();
        hPUpdate();

        if (SceneManager.GetActiveScene().name != "Workshop")
        {
       nextscene = SceneManager.GetActiveScene().buildIndex + 1;
         
            if(startedYet == true) { Livebegin(); startedYet = false; }
        }

       

    }

    public void AddToScore()
    {

        score += pointsperblockdestroyed + paddlelessscoremultiplier;
        paddlelessscoremultiplier += paddlelessscoredefault;

    }


    public void paddlehit()
    {
        paddlelessscoremultiplier = 0;
      
    }

    public void gold()
    {
        paddlelessscoredefault = paddlelessscoredefault + 20;
    }


    public bool IsAutoPlayEnabled()
    {
        return Autoplay;
    }

    private void Start()
    {
        Livebegin();
        currentLives += startingLives;
    }

    public void Livebegin()
    {
      
        currentLives += bonusLives;
        
        hPUpdate();
        ByeByeBonusLives();
      

    }

    public int HowManyLivesAreThere (){
        return currentLives;
        }

    public void ByeByeBonusLives() { bonusLives = 0; }

    public void hPUpdate()
    {
        textHP.text = currentLives.ToString();

    }

    public void Injury(int extraDamage) { currentLives--; currentLives -= extraDamage; }


    public bool Cashier(int itemcost)
    { if (itemcost <= score) { return true; }
    else { return false; }
       
    }
    public void ATM(int itemcost,string item)
    {
        score -= itemcost;
        if (item == "BonusHeart") { bonusLives++; }
       
       else if (item == "PermHeart") { currentLives++; }

        else if (item == "Save") { Save();  }
     
    }

    private void Save()
    {
        if (FindObjectOfType<Difficulty>().easyMode == true) { PlayerPrefs.SetInt("Difficulty", 1); } else { PlayerPrefs.SetInt("Difficulty", 0); }

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("NextLevel", nextscene);
        PlayerPrefs.SetInt("HP", currentLives);
      
    }

    //public void LoadOffloader( int NewScore, int NewHP)
    //{
    //    score = NewScore;
    //    currentLives = NewHP;
    
    //}

    public void findscoreandhp()
    {
        score = PlayerPrefs.GetInt("Score");
        currentLives = PlayerPrefs.GetInt("HP");
    }

    public void resetgold() { paddlelessscoredefault = 30; }
    public void plus1hp() { currentLives++; }
    public void suicide() { Destroy(gameObject); }
    
}

