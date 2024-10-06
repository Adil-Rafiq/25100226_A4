using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(LoadGame);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
