using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 100f;
    [SerializeField] private float rotationSpeed = 200f;

    [SerializeField] private Rigidbody2D rightTire;
    [SerializeField] private Rigidbody2D leftTire;
    [SerializeField] private Rigidbody2D carRb;

    private float direction, rotDirection, startX, currentX;

    [SerializeField] private float fuel = 100f;
    [SerializeField] private Image fuelBar;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI distanceText;
    void Start()
    {
        fuelBar.fillAmount = fuel / 100f;
        startX = transform.position.x;
        currentX = startX;
    }
    void Update()
    {
        if (fuel > 0)
        {
            direction = Input.GetAxisRaw("Horizontal");
            rotDirection = Input.GetAxisRaw("Vertical");
            fuel -= Mathf.Abs(direction) * Time.deltaTime;
            fuelBar.fillAmount = fuel / 100f;
            UpdateDistance();
        }
        else
            gameOverScreen.SetActive(true);
    }
    void FixedUpdate()
    {
        leftTire.AddTorque(-direction * movementSpeed * Time.fixedDeltaTime);
        rightTire.AddTorque(-direction * movementSpeed * Time.fixedDeltaTime);
        carRb.AddTorque(rotDirection * rotationSpeed * Time.fixedDeltaTime);
    }

    public void fuelPickup()
    {
        fuel = 100f;
    }
    private void UpdateDistance()
    {
        currentX = transform.position.x;
        distanceText.text = "Distance: " + (Mathf.Abs(currentX - startX)).ToString("0.0") + "m";
    }
}
