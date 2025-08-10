using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    [SerializeField] GameObject welcomePanel;        // Panel chứa màn hình ban đầu
    [SerializeField] GameObject instructionPanel;    // Panel chứa màn hình hướng dẫn
    [SerializeField] GameObject aboutusPanel;        // Panel chứa màn hình giới thiệu "About Us"

    // Hàm chuyển sang cảnh tiếp theo khi nhấn nút Play
    public void Play()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    // Hiển thị trang hướng dẫn và ẩn trang Welcome
    public void ShowInstructions()
    {
        welcomePanel.SetActive (false);               // Ẩn welcomePanel (màn hình ban đầu)
        instructionPanel.SetActive (true);            // Hiển thị instructionPanel (màn hình hướng dẫn)
        aboutusPanel.SetActive (false);               // Đảm bảo trang About Us ẩn đi
    }

    // Hiển thị trang About Us và ẩn trang Welcome
    public void ShowAboutUs()
    {
        welcomePanel.SetActive (false);               // Ẩn welcomePanel (màn hình ban đầu)
        aboutusPanel.SetActive (true);                // Hiển thị aboutusPanel (màn hình About Us)
        instructionPanel.SetActive (false);           // Đảm bảo trang hướng dẫn ẩn đi
    }

    // Ẩn trang hiện tại và quay trở lại Welcome Panel
    public void ClosePanel()
    {
        if ( instructionPanel.activeSelf )             // Nếu trang hướng dẫn đang mở
        {
            instructionPanel.SetActive (false);       // Ẩn instructionPanel
        } else if ( aboutusPanel.activeSelf )            // Nếu trang About Us đang mở
          {
            aboutusPanel.SetActive (false);           // Ẩn aboutusPanel
        }

        welcomePanel.SetActive (true);                // Hiển thị lại welcomePanel
    }
}
