using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    
    public TextMeshProUGUI contText;
    public GameObject victoriaText;

    private int contador;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        contador = 0;
        SetCountText();
        victoriaText.SetActive(false);

    }




    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void SetCountText ()
    {
        contText.text =  "Juntados: " + contador.ToString();
        if (contador >= 16)
        {
            victoriaText.SetActive(true);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            contador++;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }
}
