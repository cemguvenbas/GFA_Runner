using System;
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
    public event Action<int> GoldChanged;
    public event Action GameStarted;
    public event Action GameEnded;
    public event Action Won;
    public event Action Lost;
    public bool isGameStarted { get; private set; }
    public void StartGame()
    {
        isGameStarted = true;
        GameStarted?.Invoke();
    }
    public void EndGame()
    {
        isGameStarted = false;
        GameEnded?.Invoke();
    }

    private int _gold;
    public int Gold {
        get => _gold;
        set { 
            _gold = value;
            GoldChanged?.Invoke(_gold);
        }
    }

    public int Level { get; set; }
    public void Win() {
        Level++;
        SceneManager.LoadScene(0);
        EndGame();
        Won?.Invoke();
    }
    public void Lose() {
        //TODO Show Lose Screen
        EndGame();
        Lost?.Invoke();
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
