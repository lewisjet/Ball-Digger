using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HP;
    [SerializeField] TextMeshProUGUI SCORE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Updater(int hp, int score)
    {
        HP.text = hp.ToString();
        SCORE.text = score.ToString();
    }
}
