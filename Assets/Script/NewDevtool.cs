//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UnityEngine.SceneManagement;

//public class NewDevtool : EditorWindow
//{
//    [MenuItem("Window/Devtool")]

//    public static void ShowWindow()
//    {
//        EditorWindow.GetWindow<NewDevtool>("Devtool");
//    }


//    private void OnGUI()
//    {
//        GUILayout.Label("Devtools for playtesting");
//        //if (GUILayout.Button("Load next scene"))
//        {
//            try
//            {
//                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//            }
//            catch { Debug.LogError("Play Mode Not Active"); }
//        }
//        if (GUILayout.Button("More HP"))
//        {
//            if (FindObjectOfType<GameStatus>() != null)
//            {
//                FindObjectOfType<GameStatus>().plus1hp();
//            }

//        }

//        if (GUILayout.Button("Quick win")) { if (FindObjectOfType<Level>() != null) { FindObjectOfType<Level>().Devtool(); } }

//        GUILayout.Space(10f);
//        if (GUILayout.Button("Emergency Lose")) { try { SceneManager.LoadScene("Lose screen"); } catch { Debug.LogError("Play Mode Not Active"); } }





//    }
//}
