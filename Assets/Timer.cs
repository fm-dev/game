using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
   public float totalTime = 60.0f; // Waktu total dalam detik
    private float currentTime; // Waktu yang tersisa
    public Text timerText; // UI Text untuk menampilkan timer
    public string targetTag = "musuh";
    public Canvas gameOver;

    void Start()
    {
        // Inisialisasi waktu
        currentTime = totalTime;

        // Temukan UI Text dalam Canvas
        timerText = GetComponentInChildren<Text>();
        gameOver.enabled = false;
    }

    void Update()
    {
        // Mengurangi waktu yang tersisa
        currentTime -= Time.deltaTime;

        // Pastikan waktu tidak kurang dari 0
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        // Mengonversi waktu ke format menit:detik
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        // Menampilkan waktu pada UI Text
        timerText.text = minutes + ":" + seconds;

        // Jika waktu habis, Anda dapat menambahkan kode untuk menangani tindakan setelah waktu habis di sini
        if (currentTime <= 0)
        {
            // Contoh: Menambahkan tindakan setelah waktu habis
            // Debug.Log("Waktu telah habis!");
            GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag(targetTag);
            // Menghapus objek satu per satu
            foreach (GameObject obj in objectsToRemove)
            {
                Destroy(obj);
            }
            gameOver.enabled = true;
            Invoke("pindahKeGameOver", 3f);

        }
    }
    void pindahKeGameOver(){
        SceneManager.LoadScene("GameOver");    
    }
}
