using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Parent;
    public float rotate = 20f;
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
	transform.position = player.transform.position + offset;
	if(Input.GetKey (KeyCode.Q))
	{
		transform.RotateAround(Parent.transform.position, Parent.transform.up, rotate*Time.deltaTime);
		offset = transform.position - player.transform.position;
	}

	if(Input.GetKey (KeyCode.E))
	{	
		transform.RotateAround(Parent.transform.position, Parent.transform.up, -1 * rotate*Time.deltaTime);
		offset = transform.position - player.transform.position;
	}
    }
}
