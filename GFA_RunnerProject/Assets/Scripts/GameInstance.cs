using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public static class PlayerData
//{

//}
public class GameInstance : MonoBehaviour
{
    private static GameInstance _instance;
    public static GameInstance Instance
    {
        get
        {
            return _instance;
        }
    }
    public int Gold { get; set; }
    public int Level { get; set; }
    public void Win() {
        Level++;
        SceneManager.LoadScene(0);
    }
    public void Lose() {
        //TODO Show Lose Screen
        SceneManager.LoadScene(0);
    }


    private void Awake()
    {
        if (_instance && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Undestroyeble
        }
    }
}
