using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private float speed = 60.0f; // Car's forward movement speed

    private Rigidbody carRigidbody;

    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
      
        // Move the car forward at the set speed
        carRigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            
            // Destroy the fuel GameObject
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            
            // Destroy the fuel GameObject
            Destroy(other.gameObject);
        }
    }


}
