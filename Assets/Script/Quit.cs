using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] GameObject audioarea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public  void quitz()
    {
        Application.Quit();

    }
    public void OST()
    {
        try
        {
            Application.OpenURL(url);
            audioarea.GetComponent<AudioSource>().mute = true;
        }
        catch { Debug.LogError("wait... what website?"); }
    }
}
