using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PertanyaanUi : MonoBehaviour
{
    public GameObject objekLain; // Referensi ke objek lain yang memiliki Rigidbody
    private Rigidbody rbObjekLain;
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
    public Text teksCanvas;
    public Canvas canvas;
    private System.Random randomGenerator;
    public int randomNumber;
    public GameObject objekYangAkanDihancurkan;
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
        Destroy(objekYangAkanDihancurkan);
        rbObjekLain.isKinematic = false;
        randomNumber = randomGenerator.Next(1, 4);
        canvas.enabled = false; // Nonaktifkan Canvas saat tombol di-klik
    }
}
