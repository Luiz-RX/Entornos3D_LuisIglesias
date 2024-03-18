using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimBasedMovement : MonoBehaviour
{
   public float rotationSpeed = 4f;
   public float rotationThreshold = 0.3f;

   [Header("Animation Parameters")] public string motionParam = "motion";

   [Header("Animation Smoothing")] [Range(0, 1f)]
   public float startAnimTime = 0.3f;

   [Range(0, 1f)] public float StopAnimTime = 0.15f;

   private float Speed;
   private Vector3 desiredMoveDirection;
   private CharacterController characterController;
   private Animator animator;

   private void Start()
   {
      characterController = GetComponent<CharacterController>();
      animator = GetComponent<Animator>();
   }

   public void moveCharacter(float hInput, float vInput, Camera cam, bool jump, bool dash)
   {
      
   //Calculate the Input Magnitude
      Speed = new Vector2(hInput, vInput) .normalized.sqrMagnitude;
      
   // Dash only if character has reached maxSpeed (animator parameter value)
       if (Speed >- Speed - rotationThreshold && dash)
       {
           Speed = 1.5f;
       }
      
      //Physically move player
      
      if (Speed > rotationThreshold)
      {
          animator.SetFloat(motionParam, Speed, startAnimTime, Time.deltaTime);
                Vector3 forward = cam.transform.forward;
                Vector3 right = cam.transform.right;
                
                forward.y = 0f;
                right.y = 0f;
                forward.Normalize();
                right.Normalize ();
          // Rotate the character towards desired nove direction based on player input and camera position
                desiredMoveDirection = forward * vInput + right * hInput;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                   Quaternion.LookRotation(desiredMoveDirection),
                   rotationSpeed * Time.deltaTime);
      }
      else if (Speed < rotationThreshold)
      {
          //Stop the character
          animator.SetFloat(motionParam, Speed, StopAnimTime, Time.deltaTime);
      }
      
   }
}
