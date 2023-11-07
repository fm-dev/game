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
    public int pToAdd = 100;
    public int section;
    public string[] Easy = {
        "Apakah Abdurrahman Wahid presiden ketiga Republik Indonesia?",
        "Apakah MPR singkatan dari majelis Permusyawaratan Rakyat?", 
        "Apakah benar hari Pancasila pada tanggal 17 Agustus 1945", 
        "Apakah benar hewan yang hidup di darat dan air disebut mamalia?",
        "Bhineka tunggal Ika merupakan semboyan dari Indonesia?",
        "Apakah benar 2+4+8=15?",
        "Malin Kundang merupakan cerita rakyat dari sumatera barat?",
        "CO2 merupakan oksigen?",
        "Tajmahal dari India?",
        "Mata uang indonesia adalah rupiah?",
        "Ikan bernafas dengan insang?",
        "Indonesia dipimpin oleh presiden?",
        "Ikan hidup diudara?",
        "Indonesia merupakan populasi terbanyak no 1 didunia?",
        "Buah mengandung vitamin C",
        "4 sehat 5 sempurna, 5 sempurnanya adalah jus?",
        "Pengetik naskah proklamasi adalah Sayuti Malik?",  
        "Megawati presiden ke empat?",  
        "Katak merupakan hewan amphibi?",  
        "Herbivora adalah hewan pemakan daging"  
    };
    public string[] jwbesey = {
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
        "Benar",
        "Benar",
        "Salah",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Salah"
    };
    public string[] medium = {
        "Iklim diindonesia adalah tropis?",
        "Pencipta lagi Indonesia raya R.A Kartini", 
        "Rumah gadang merupakan rumah ada dari sumater barat", 
        "Sungai Nil merupakan sungai terpanjang di dunia?",
        "Gurun Saraha merupakan gurun terluas di dunia?",
        "Dinar merupakan mata uang negara Irak?",
        "Negara Asean terdiri dari 11?",
        "Matahari merupakan pusat peredaran tatasurya?",
        "Indonesia dijajah Belanda 35 tahun?",
        "Penemu mesin uap adalah Thomas Alfa Edison?",
        "Arah jam 9 adalah arah barat?",
        "Udara yang bergerak adalah angin?",
        "Pusat keuangan Amerika Serikat adalah newyork?",
        "Kota paling boros listrik diasia adalah Tokyo?",
        "Wahana kereta luncur yang sangat cepat dan menguji adrenalin adalah kereta api?",
        "Alat musik gambus berasal dari Riau?",
        "Presiden Turki tahun 2022 adalah Erdogan?",  
        "Amar makruf adalah wakil presiden Indonesia tahun 2023?",  
        "Batu yang bisa mengapung disebut batu Apung?",  
        "Mie yang berasal dari Jepang adalah ramen?"  
    };
    public string[] jwbMedium = {
        "Benar",
        "Salah",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Salah",
        "Benar",
        "Benar",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Benar"
    };
    public string[] hard = {
        "Samudra Pasifik merupakan samudra terkecil?",
        "Amerika merupakan negara terluas keempat didunia?", 
        "Percampuran warna kuning dan biru adalah hijau?", 
        "Apakah simbol L merupakan atom hidrogen",
        "Apakah ikan paus bernafas dengan paru paru?",
        "Seagames diadakan 4 tahun sekali?",
        "Pencipta lagi padamu negri yaitu kusbini?",
        "Amuba merupakan hewan terkecil?",
        "Untuk buat halaman baru diword dengan control N?",
        "Vatikan merupakan negara terluas didunia?",
        "Apakah ibukota Banten diserang?",
        "Apakah hari kebangkitan nasional tanggal 2 Mei?",
        "Apakah benar Gorontalo disebut serambi Madinah?",
        "Apakah negara Thailand tidak pernah dijajah?",
        "Apakah benar bendera Belanda berwarna merah biru?",
        "Apakah benar Dollar AS yang nilainya mempengaruhi harga didunia?",
        "1 jam = 3600 menit?",  
        "Ibukota Jawa tengah adalah Semarang?",  
        "Ibukota Amerika Serikat adalah newyork?",  
        "Menara yang ada di Paris adalah menara Pisa?"  
    };
     public string[] jawabanHard = {
        "Salah",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Benar",
        "Salah",
        "Salah"
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
        randomNumber = randomGenerator.Next(0, 17);
    }
    public void Start()
    {
        rbObjekLain = objekLain.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        settingPertanyaan();
        PlayerPrefs.SetInt("MyDataKey", pToAdd);
        PlayerPrefs.Save(); // Simpan data ke penyimpanan PlayerPrefs
        
    }
    void settingPertanyaan(){
        Debug.Log(randomNumber);
        string level = PlayerPrefs.GetString("setLevel");
        if(level == "easy")
        {
            teksCanvas.text = Easy[randomNumber];
        }
        if(level == "medium")
        {
            teksCanvas.text = medium[randomNumber];
        }
        if(level == "hard")
        {
            teksCanvas.text = hard[randomNumber];
        }
    }
    
    public void NonaktifkanCanvasOnClick()
    {
        string level = PlayerPrefs.GetString("setLevel");
        if(level == "easy")
        {
            if(jwbesey[randomNumber] == "Benar")
            {
                spawn.SpawnObject();
                spawn2.SpawnObject();
                spawn3.SpawnObject();
                spawn4.SpawnObject();
                spawn5.SpawnObject();
                spawn6.SpawnObject();
                spawn7.SpawnObject();
                spawn8.SpawnObject();
                spawn9.SpawnObject();
                scoreManager.AddScore(pToAdd);
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
        }
        if(level == "medium")
        {
            if(jwbMedium[randomNumber] == "Benar")
            {
                spawn.SpawnObject();
                spawn2.SpawnObject();
                spawn3.SpawnObject();
                spawn4.SpawnObject();
                spawn5.SpawnObject();
                spawn6.SpawnObject();
                spawn7.SpawnObject();
                spawn8.SpawnObject();
                spawn9.SpawnObject();
                scoreManager.AddScore(pToAdd);
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

        }
        if(level == "hard")
        {
            if(jawabanHard[randomNumber] == "Benar")
            {
                spawn.SpawnObject();
                spawn2.SpawnObject();
                spawn3.SpawnObject();
                spawn4.SpawnObject();
                spawn5.SpawnObject();
                spawn6.SpawnObject();
                spawn7.SpawnObject();
                spawn8.SpawnObject();
                spawn9.SpawnObject();
                scoreManager.AddScore(pToAdd);
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

        }
        rbObjekLain.isKinematic = false;
        canvas.enabled = false;
        randomNumber = randomGenerator.Next(0, 17);
        
    }
    public void salahBtn()
    {
        string level = PlayerPrefs.GetString("setLevel");
        if(level == "easy")
        {
            if(jwbesey[randomNumber] == "Salah")
            {

                scoreManager.AddScore(pToAdd);
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
        }
        if(level == "medium")
        {
            if(jwbMedium[randomNumber] == "Salah")
            {

                scoreManager.AddScore(pToAdd);
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
        }
        if(level == "hard")
        {
            if(jawabanHard[randomNumber] == "Salah")
            {

                scoreManager.AddScore(pToAdd);
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
        }
        rbObjekLain.isKinematic = false;
        canvas.enabled = false;
        randomNumber = randomGenerator.Next(0, 17);
        PlayerPrefs.SetInt("MyDataKey", pToAdd);
        PlayerPrefs.Save(); // Simpan data ke penyimpanan PlayerPrefs
    }
}
