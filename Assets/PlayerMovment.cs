using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float kecepatan;
    Rigidbody rb;
    Animator anim;
    public float rotationSpeed;

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
        Debug.Log(rotationInput);

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
