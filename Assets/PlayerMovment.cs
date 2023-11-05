using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovment : MonoBehaviour
{
    public float kecepatan;
    Rigidbody rb;
    Animator anim;
    public float rotationSpeed;
    public Slider healthSlider; // Slider yang akan berkurang ketika pemain bersentuhan dengan musuh
    public float maxHealth = 100f;
    public float damageAmount = 10f;
    public Canvas canvas;
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
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("musuh")) // Ganti "Enemy" dengan tag yang digunakan oleh musuh
        {
            ReduceHealth();
            canvas.enabled = true;
            Invoke("Berdarah", 2.0f);
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
            }
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
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
/*        anim.SetBool("IsRight", rightrun);
        anim.SetBool("IsLeft", leftrun);*/
        anim.SetBool("IsRun", walking);
    }
}
