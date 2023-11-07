using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovment : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float kecepatan;
    Rigidbody rb;
    Animator anim;
    public float rotationSpeed;
    public Slider healthSlider; // Slider yang akan berkurang ketika pemain bersentuhan dengan musuh
    public float maxHealth = 100f;
    public float damageAmount = 100f;
    public Canvas canvas;
    public Canvas gameOver;
    public Canvas finish;
    public string targetTag = "musuh";
    public int jumlahMusuh = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
        else
        {
            Debug.LogError("Health Slider is not assigned.");
        }
        canvas.enabled = false;
        gameOver.enabled = false;
        finish.enabled = false;

       
    }
    public void Update(){

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("musuh")) // Ganti "Enemy" dengan tag yang digunakan oleh musuh
        {
            jumlahMusuh++;
            ReduceHealth();
            canvas.enabled = true;
            Invoke("Berdarah", 2.0f);
            if(jumlahMusuh == 2)
            {
                Debug.Log("lebihdari3");
            }
        }
        if(other.CompareTag("Finish")){
            finish.enabled = true;
            GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag(targetTag);
            // Menghapus objek satu per satu
            foreach (GameObject obj in objectsToRemove)
            {
                Destroy(obj);
            }
            
            Invoke("pindahKeGameOver", 3f);
            
        }
    }

    void Berdarah(){
        canvas.enabled = false;
    }

    void ReduceHealth()
    {
        if (healthSlider != null)
        {
            healthSlider.value -= damageAmount;
            if (healthSlider.value <= 0)
            {
                // Game over atau logika kematian pemain di sini
                Debug.Log("Game Over");
                
                Invoke("pindahKeGameOver", 3f);
                gameOver.enabled = true;
            }
        }
    }
    void pindahKeGameOver(){
        SceneManager.LoadScene("GameOver");    
    }



    void FixedUpdate()
    {
        Movement();
        Rotation();
        // if (isMoving && !audioSource.isPlaying)
        // {
        //     audioSource.Play();
        // }
        // if (!isMoving && audioSource.isPlaying)
        // {
        //     audioSource.Stop();
        // }
       

    }
    

    void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float moveAnim = new Vector2(moveX, moveZ).magnitude;

        Vector3 movement = new Vector3(moveX, -1, moveZ);
        rb.velocity = transform.TransformDirection(movement) * kecepatan;
        Animating(moveX, moveZ);
    }

    void Rotation()
    {
        float rotationInput = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(Vector3.up, rotationInput);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        bool rightrun = h == 1f;
        bool leftrun = h == -1f;
        anim.SetBool("IsRun", walking);
    }
}   

