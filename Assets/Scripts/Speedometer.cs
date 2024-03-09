using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody carRigidbody;
    public TextMeshProUGUI speedText;
    // Update is called once per frame
    void Update()
    {
        float speedMS = carRigidbody.velocity.magnitude;
        float speedKMH = speedMS*3.6f;
        speedText.text = "Speed : "+Mathf.Round(speedKMH) + " Km/h";
    }
}
