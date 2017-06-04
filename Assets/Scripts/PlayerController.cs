﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;
    private Quaternion targetRotation;

    private CharacterController controller;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
		
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

        }
        Vector3 motion = input;
        input *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f:1;
        input *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
    }
}
