using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PertanyaanController : MonoBehaviour
{
    public GameObject objekLain; // Referensi ke objek lain yang memiliki Rigidbody
    public Canvas canvas;
    private Rigidbody rbObjekLain;
    public string targetTag = "musuh"; // Ganti "YourTag" dengan tag yang ingin Anda ubah
    public bool newIsKinematicValue = true; // Ganti dengan nilai bool yang Anda inginkan
    private void Start()
    {
        rbObjekLain = objekLain.GetComponent<Rigidbody>();
        canvas.enabled = false; // Mulai dengan nonaktifkan Canvas
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ganti "Player" dengan tag yang sesuai untuk objek pemain
        {
            rbObjekLain.isKinematic = true;
            canvas.enabled = true; // Aktifkan Canvas ketika pemain menyentuh objek tertentu
            GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag(targetTag);
            // Menghapus objek satu per satu
            foreach (GameObject obj in objectsToRemove)
            {
                Destroy(obj);
            }
        }
        else
        {
            canvas.enabled = false;
        }
         // Mengambil semua objek dengan tag yang sesuai
       
    }
    
}
