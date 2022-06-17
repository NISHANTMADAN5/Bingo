using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("Game3x3");
    }
    public void Next()
    {
        SceneManager.LoadScene("Game4x4");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
