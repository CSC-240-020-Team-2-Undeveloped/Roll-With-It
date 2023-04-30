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
    public GameObject winTextObject;
    public GameObject doorOpenTextObject;
    public GameObject cam;

    private Rigidbody rb;
    private int count;
    private int countWin;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
	  countWin = 0;

        SetKeyCountText();
	  SetWinText();
        winTextObject.SetActive(false);
	  doorOpenTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetKeyCountText()
    {
        KeyCountText.text = "Keys Collected: " + count.ToString();
         if(count == 4)
        {
            doorOpenTextObject.SetActive(true);
        }
    }

    void SetWinText()
    {
	  if(countWin == 1)
	  {
		winTextObject.SetActive(true);
	  }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        cam.transform.Rotate(-30.0f,0,0);
        movement = Quaternion.Euler(0,cam.transform.eulerAngles.y,0) * movement;
        print(cam.transform.eulerAngles.y);
        cam.transform.Rotate(30.0f,0,0);

        rb.AddForce(movement * speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Key1"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;

        SetKeyCountText();
      }
      if(other.gameObject.CompareTag("Key2"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;

        SetKeyCountText();
      }
      if(other.gameObject.CompareTag("Key3"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;

        SetKeyCountText();
      }
      if(other.gameObject.CompareTag("Key4"))
      {
        other.gameObject.SetActive(false);
        count = count + 1;
        
        SetKeyCountText();
      }
    }
}