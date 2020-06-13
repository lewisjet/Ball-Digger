using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void MainMenu() { FindObjectOfType<SceneLoader>().restart(); }
    public void ReplayLv() { FindObjectOfType<SceneLoader>().Reload(); }
}
