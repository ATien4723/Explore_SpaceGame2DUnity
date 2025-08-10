using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text finalScoreText;

    private void Start()
    {
        if ( GameSession.Instance != null ) {
            int finalScore = GameSession.Instance.GetScore ();
            finalScoreText.text = "Final Score: " + finalScore.ToString ();
        }
    }

    public void Restart()
    {
        if ( GameSession.Instance != null ) {
            GameSession.Instance.ResetScoreAndLives ();
        }

        SceneManager.LoadScene (0);
    }

    public void Quit()
    {
        UnityEngine.Application.Quit ();  // Sử dụng UnityEngine.Application rõ ràng
    }
}
