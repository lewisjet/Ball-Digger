using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "News description")]
public class News : ScriptableObject
{
 [TextArea (3,0)]   [SerializeReference] string info = "there should be a workshop at 1 and all multiples of 5. place in order 0=1 1=5 ect...";


  [Tooltip ("What level were you just playing?")]  [SerializeField] int levelID;
  [Tooltip ("What will be in the news today?")]   [TextArea(14,10)] [SerializeField]  string text;

    public string ReturnText()
    {
        return text;
    }

    public int ReturnLevelID()
    {
        return levelID;
    }



}
