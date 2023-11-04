using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PertanyaanController : MonoBehaviour
{
    public GameObject objekLain; // Referensi ke objek lain yang memiliki Rigidbody
    public Canvas canvas;
    private Rigidbody rbObjekLain;
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
        Vector3 posisiSaatIni = objekLain.transform.position;
        if (other.CompareTag("Player")) // Ganti "Player" dengan tag yang sesuai untuk objek pemain
        {
            rbObjekLain.isKinematic = true;
            canvas.enabled = true; // Aktifkan Canvas ketika pemain menyentuh objek tertentu
        }
        else
        {
            canvas.enabled = false;
        }
    }
    
}
