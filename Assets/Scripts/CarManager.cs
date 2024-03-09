
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarManager : MonoBehaviour
{
    public static int fuel = 0; // Static variable to store fuel
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the fuel text
    // [SerializeField] private GameObject gameOver;
    // [SerializeField] private GameObject car; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(fuel<0)
        // {
        //     GameOver();
        // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            // Access the static fuel variable using the class name
            fuel += 10;
            scoreText.text = "Score: " + fuel;
            // Debug.Log("Fuel added: " + fuel);
            
            // Destroy the fuel GameObject
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            // Access the static fuel variable using the class name
            fuel -= 10;
            scoreText.text = "Score: " + fuel;
            // Debug.Log("Fuel added: " + fuel);
            
            // Destroy the fuel GameObject
            Destroy(other.gameObject);
        }
    }

    // private void GameOver()
    // {
    //     gameOver.SetActive(true);
    //     Time.timeScale = 0f;
    //     car.SetActive(false)

    // }
}
