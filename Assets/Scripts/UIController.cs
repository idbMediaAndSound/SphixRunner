using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject m_GameOverObject;
    [SerializeField] GameObject m_ScoreScreen;
    [SerializeField] Text m_MaxDistanceText;
    [SerializeField] Text m_CollectedCoins;
    [SerializeField] Text m_CollectedCoinsOnScreen;
    [SerializeField] Player m_Player;
    [SerializeField] GameObject m_SpawnManager;

    private void Update()
    {
        m_CollectedCoinsOnScreen.text = $"Collected Coins: {m_Player.m_CollectedCoins} debens";
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
        m_Player.gameIsActive = true;
        
    }

    public void ShowGameOverScreen()
    {
        m_Player.gameIsActive = false;
        m_GameOverObject.SetActive(true);
        m_SpawnManager.SetActive(false);
        m_ScoreScreen.SetActive(false);
        string distanceTraveled = Mathf.Ceil(m_Player.maxDistance).ToString();
        m_MaxDistanceText.text = $"Max Distance: {distanceTraveled} Mewts";
        m_CollectedCoins.text = $"Collected Coins: {m_Player.m_CollectedCoins} debens";
    }

}
