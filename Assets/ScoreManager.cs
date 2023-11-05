using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        // Pastikan Anda memiliki referensi ke komponen Text pada objek yang menampilkan skor.
        if (scoreText == null)
        {
            Debug.LogError("Score Text component is not assigned.");
        }

        // Set nilai awal skor ke 0 saat permainan dimulai.
        UpdateScoreText();
    }

    // Fungsi untuk menambahkan skor.
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText();
    }

    // Fungsi untuk memperbarui teks skor pada layar.
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
