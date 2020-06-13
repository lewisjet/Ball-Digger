using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
  [SerializeField] Level level = null;

    private void Awake()
    {
        if (FindObjectsOfType<Difficulty>().Length > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

  public  bool easyMode = false;

    // Start is called before the first frame update
  public  void StartThisOne()
    {
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level && easyMode)
        {
            if (!level.shopopen) { level.shopopen = true; }
        }


      
    }

    public void ClearLVL() { level = null; }


    public void UpdateEasyMode(bool yN) {if (yN) { easyMode = true; } else { easyMode = false; } }

}
