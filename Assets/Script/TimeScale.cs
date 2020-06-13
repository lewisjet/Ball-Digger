using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField]public float GameSpeed = 1f;
    
    void Start()
    {

        Time.timeScale = GameSpeed;
    }
}
