using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PertanyaanUi : MonoBehaviour
{
    // public GameObject objectToSpawn;
    // public Transform spawnPoint;
    public GameObject objekLain; // Referensi ke objek lain yang memiliki Rigidbody
    private Rigidbody rbObjekLain;
    public ScoreManager scoreManager;
    public int pointsToAdd = 10;
    public int section;
    public string[] pertanyaanEasy = {
        "Apakah Abdurrahman Wahid presiden ketiga Republik Indonesia?",
        "Apakah MPR singkatan dari majelis Permusyawaratan Rakyat?", 
        "Apakah benar hari Pancasila pada tanggal 17 Agustus 1945", 
        "Apakah benar hewan yang hidup di darat dan air disebut mamalia?",
        "Bhineka tunggal Ika merupakan semboyan dari Indonesia?",
        "Apakah benar 2+4+8=15?",
        "Malin Kundang merupakan cerita rakyat dari sumatera barat?",
        "CO2 merupakan oksigen?",
        "Tajmahal dari India?",
        "Mata uang indonesia adalah rupiah?"


    };
    public string[] jawabanEasy = {
        "Salah",
        "Benar",
        "Salah",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Benar",
    };
    public Text teksCanvas;
    public SpawnMusuh spawn, spawn2, spawn3, spawn4,spawn5,spawn6,spawn7,spawn8,spawn9;
    public Canvas canvas;
    private System.Random randomGenerator;
    public int randomNumber;
    public GameObject objekYangAkanDihancurkan;
    public string targetTag = "musuh"; // Ganti "YourTag" dengan tag yang ingin Anda ubah
    public bool newIsKinematicValue = true; // Ganti dengan nilai bool yang Anda inginkan
    public SpawnMusuh spawnlagi;
    public int Score  = 0 ;
    public void Awake(){
        randomGenerator = new System.Random();
        randomNumber = randomGenerator.Next(1, 10);
    }
    public void Start()
    {
        rbObjekLain = objekLain.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        settingPertanyaan();
    }
    void settingPertanyaan(){
        
        teksCanvas.text = pertanyaanEasy[randomNumber];
    }
    
    public void NonaktifkanCanvasOnClick()
    {
       
        if(jawabanEasy[randomNumber] == "Benar")
        {
            Score = Score + 100;
            spawn.SpawnObject();
            spawn2.SpawnObject();
            spawn3.SpawnObject();
            spawn4.SpawnObject();
            spawn5.SpawnObject();
            spawn6.SpawnObject();
            spawn7.SpawnObject();
            spawn8.SpawnObject();
            spawn9.SpawnObject();
            scoreManager.AddScore(pointsToAdd);
            Destroy(objekYangAkanDihancurkan);
             // Nonaktifkan Canvas saat tombol di-klik
            // Mengambil semua objek dengan tag yang sesuai
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("musuh");

            // Mengubah nilai isKinematic pada semua objek dengan tag yang sesuai
            foreach (GameObject obj in objectsWithTag)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Debug.Log("masuk");
                    rb.isKinematic = newIsKinematicValue;
                }
            }

        }
        else{
            spawn.SpawnObject();
            spawn2.SpawnObject();
            spawn3.SpawnObject();
            spawn4.SpawnObject();
            spawn5.SpawnObject();
            spawn6.SpawnObject();
            spawn7.SpawnObject();
            spawn8.SpawnObject();
            spawn9.SpawnObject();
            canvas.enabled = false;
            spawnlagi.SpawnObject();
            // Mengambil semua objek dengan tag yang sesuai
             Destroy(objekYangAkanDihancurkan);
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("musuh");

            // Mengubah nilai isKinematic pada semua objek dengan tag yang sesuai
            foreach (GameObject obj in objectsWithTag)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Debug.Log("masuk");

                    rb.isKinematic = newIsKinematicValue;
                }
            }
        }
        rbObjekLain.isKinematic = false;
        canvas.enabled = false;
        randomNumber = randomGenerator.Next(1, 4);
    }
    public void salahBtn()
    {
        if(jawabanEasy[randomNumber] == "Salah")
        {
            scoreManager.AddScore(pointsToAdd);
            spawn.SpawnObject();
            spawn2.SpawnObject();
            spawn3.SpawnObject();
            spawn4.SpawnObject();
            spawn5.SpawnObject();
            spawn6.SpawnObject();
            spawn7.SpawnObject();
            spawn8.SpawnObject();
            spawn9.SpawnObject();
            Destroy(objekYangAkanDihancurkan);
            // Mengambil semua objek dengan tag yang sesuai
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("musuh");

            // Mengubah nilai isKinematic pada semua objek dengan tag yang sesuai
            foreach (GameObject obj in objectsWithTag)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = newIsKinematicValue;
                }
            }
        }
        else{
            Destroy(objekYangAkanDihancurkan);
            spawnlagi.SpawnObject();
            spawn.SpawnObject();
            spawn2.SpawnObject();
            spawn3.SpawnObject();
            spawn4.SpawnObject();
            spawn5.SpawnObject();
            spawn6.SpawnObject();
            spawn7.SpawnObject();
            spawn8.SpawnObject();
            spawn9.SpawnObject();
            // Mengambil semua objek dengan tag yang sesuai
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("musuh");

            // Mengubah nilai isKinematic pada semua objek dengan tag yang sesuai
            foreach (GameObject obj in objectsWithTag)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = newIsKinematicValue;
                }
            }
        }
        rbObjekLain.isKinematic = false;
        canvas.enabled = false;
        randomNumber = randomGenerator.Next(1, 4);
    }
}