using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI KeyCountText;
    public GameObject winTextObject1;
    public GameObject winTextObject2;
    public GameObject winTextObject3;
    public GameObject welcomeTextObject;
    public GameObject doorOpenTextObject;
    public GameObject invisibleDoor;
    public GameObject cam;

    private Rigidbody rb;
    private int count;
    private int countWin;
    private float movementX;
    private float movementY;

    public Vector3 respawnVec;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count = 3;

      SetKeyCountText();
      winTextObject1.SetActive(false);
      winTextObject2.SetActive(false);
      winTextObject3.SetActive(false);
      doorOpenTextObject.SetActive(false);

      respawnVec = transform.position;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

        welcomeTextObject.SetActive(false);

    }

    void SetKeyCountText()
    {
        KeyCountText.text = "Keys Collected: " + count.ToString();
		print("Does work");
         if(count == 4)
        {
            doorOpenTextObject.SetActive(true);
            invisibleDoor.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        cam.transform.Rotate(-30.0f,0,0);
        movement = Quaternion.Euler(0,cam.transform.eulerAngles.y,0) * movement;
        cam.transform.Rotate(30.0f,0,0);

        rb.AddForce(movement * speed);
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.R))
      {
        transform.position = respawnVec;
      }
    }
    
    private void OnTriggerEnter(Collider other)
    {
      print(other.name);
      if(other.gameObject.CompareTag("PickUp"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;

        SetKeyCountText();
      }
      if(other.gameObject.CompareTag("Respawn"))
      {
        transform.position = respawnVec;
      }
      if(other.gameObject.CompareTag("SpawnPoint"))
      {
        respawnVec = other.transform.position;
      }
      if(other.gameObject.CompareTag("CubePickUp"))
      {
        winTextObject1.SetActive(true);
        winTextObject2.SetActive(true);
        winTextObject3.SetActive(true);
        doorOpenTextObject.SetActive(false);
        other.gameObject.SetActive(false);
      }
    }
}