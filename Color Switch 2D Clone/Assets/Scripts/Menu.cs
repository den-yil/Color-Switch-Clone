using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    private void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
