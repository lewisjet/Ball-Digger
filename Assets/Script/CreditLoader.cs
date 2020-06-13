using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditLoader : MonoBehaviour
{
    public bool win = false;
    public Animator animator;
   
    // Update is called once per frame
  public  void Work()
    {
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        win = true;
        Debug.Log("yay");
        animator.SetTrigger("Start");
        Debug.Log("moomoo");
        yield return new WaitForSeconds(1.5f);
       
            Debug.Log("woohoo");
            FindObjectOfType<SceneLoader>().LoadNextScene();
        

    }

    



}
