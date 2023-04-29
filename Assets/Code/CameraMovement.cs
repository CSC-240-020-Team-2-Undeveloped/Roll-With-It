using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public float rotate = 20f;
  public GameObject player;
  public Vector3 offset;

  void Start()
  {
      offset = transform.position - player.transform.position;
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey (KeyCode.Q))
    {	
      offset = Quaternion.Euler(0,-rotate*Time.deltaTime,0) * offset;
      transform.Rotate(-45.0f,0,0);
      transform.Rotate(0,-rotate*Time.deltaTime,0);
      transform.Rotate(45.0f,0,0);
    }

    if(Input.GetKey (KeyCode.E))
    {	
      offset = Quaternion.Euler(0,rotate*Time.deltaTime,0) * offset;
      transform.Rotate(-45.0f,0,0);
      transform.Rotate(0,rotate*Time.deltaTime,0);
      transform.Rotate(45.0f,0,0);
      
    }
    transform.position = player.transform.position + offset;
  }
}
