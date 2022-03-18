using System;
using UnityEngine;

namespace Code
{
    public class CatMoving : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [Header("Moving")]
        [SerializeField] private float movingSpeed;
        [SerializeField] private float rotationSpeed = 100f;
        [Header("Jumping")] 
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float groundCheckerRadius = 2f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpHigh = 2f;
        [SerializeField] private float gravityForce = -9.8f;
        
        
        private Actions actions;
        private int jumpCount;
        private const int JumpMax = 3;

        private Vector3 gravity;
        
        
        private void Start()
        {
            actions = new Actions();
            actions.Enable();
        }


        private void Update()
        {
            var input = actions.Payer.Moving.ReadValue<Vector2>();
            var jump = actions.Payer.Jump.triggered;

            MoveCat(input);
            Jump(jump);
        }

        private void Jump(bool jump)
        {
            gravity.y += gravityForce * Time.deltaTime;
            
            if (IsGrounded())
            {
                jumpCount = 0;
                gravity = Vector3.zero;
            }
            
            if (jump)
            {
                if(jumpCount >= JumpMax) return;
                jumpCount++;
                gravity.y += gravityForce * -jumpHigh;
                Debug.Log($"Jump {gravity}");
            }
            
            Debug.Log($"gravity {gravity}");
            player.position += gravity * Time.deltaTime;
            
        }

        private bool IsGrounded()
        {
            return Physics.CheckSphere(groundChecker.position, groundCheckerRadius, groundLayer);
        }


        private void MoveCat(Vector2 input)
        {
            if(input == Vector2.zero) return;
            player.position += transform.forward * movingSpeed * Time.deltaTime;
            if(jumpCount > 0 && jumpCount < 3) return;
            player.RotateAround(player.position, Vector3.up, rotationSpeed * input.x * Time.deltaTime);
        }


        private void OnDestroy()
        {
            actions.Disable();
        }
    }
}