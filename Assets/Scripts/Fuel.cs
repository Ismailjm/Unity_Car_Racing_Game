using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 35 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the static fuel variable using the class name
            CarManager.fuel += 10;
            Debug.Log("Fuel added: " + CarManager.fuel);
            
            // Destroy the fuel GameObject
            Destroy(gameObject);
            
        }
    }
}
