using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowTarget : MonoBehaviour
{
    public string targetTag; // Tag objek target yang akan diikuti
    public float rotationSpeed = 5.0f;
    public float speed;

    private Transform target;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        // Mencari objek target berdasarkan tag
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            // Debug.LogError("Objek target dengan tag " + targetTag + " tidak ditemukan.");
        }
    }

    void Update()
    {
        jalan("jalan");
        
    }
    public void jalan(string jalan)
    {
        if(jalan == "jalan")
        {    
            if (target != null)
            {
                navMeshAgent.SetDestination(target.position);
                // Tentukan vektor arah ke target
                Vector3 directionToTarget = target.position - transform.position;

                // Hitung rotasi yang sesuai menggunakan Quaternion Look Rotation
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Menggunakan Lerp untuk mengubah rotasi secara halus
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        else{
            Debug.Log("testing");
        }
    }
   
}
