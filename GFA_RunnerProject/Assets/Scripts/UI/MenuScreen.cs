using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonPressed);
    }
    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonPressed);

    }
    private void OnPlayButtonPressed()
    {
        GameInstance.Instance.StartGame();
    }
}
