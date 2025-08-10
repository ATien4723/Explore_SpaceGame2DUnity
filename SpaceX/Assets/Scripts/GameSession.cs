using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance { get; private set; }

    [SerializeField] int playerLives = 3; // Mặc định là 3 mạng
    [SerializeField] int scores = 0; // Mặc định là 0 điểm

    [SerializeField] UnityEngine.UI.Text livesText;  
    [SerializeField] UnityEngine.UI.Text scoresText;
    [SerializeField] GameObject gameOverPanel;

    private void Awake()
    {
        if ( Instance == null ) {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }

    void Start()
    {
        UpdateUI (); // Cập nhật UI khi bắt đầu trò chơi
    }

    public void ProcessPlayerDeath()
    {
        if ( playerLives > 1 ) {
            TakeLife ();
        } else {
            ShowGameOverPanel ();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (currentSceneIndex);
        UpdateUI ();
        Time.timeScale = 1f;
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive (true);
        Time.timeScale = 0f;
    }

    // Reset lại trò chơi và quay về màn chính
    public void ResetGameSession()
    {
        ResetScoreAndLives ();  // Reset điểm và mạng trước khi chuyển cảnh
        SceneManager.LoadScene (0);  // Load menu chính
        Time.timeScale = 1f;
        Destroy (gameObject); // Hủy đối tượng GameSession hiện tại
    }

    // Reset lại điểm và mạng
    public void ResetScoreAndLives()
    {
        scores = 0;
        playerLives = 3;
        UpdateUI ();
    }

    public void Retry()
    {
        ResetScoreAndLives ();  // Reset điểm và mạng khi nhấn nút retry
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);  // Tải lại màn chơi hiện tại
        gameOverPanel.SetActive (false);  // Ẩn panel Game Over
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        ResetScoreAndLives ();  // Reset trước khi quay về menu
        SceneManager.LoadScene (0);  // Load menu chính
        Destroy (gameObject); // Hủy GameSession để tạo mới khi quay lại
    }

    public void AddScores(int score)
    {
        scores += score;
        UpdateUI ();
    }

    public int GetScore()
    {
        return scores;
    }

    private void UpdateUI()
    {
        // Cập nhật các giá trị mạng và điểm trên UI
        if ( livesText != null ) {
            livesText.text = playerLives.ToString ();
        }

        if ( scoresText != null ) {
            scoresText.text = scores.ToString ();
        }
    }
}
