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
        [SerializeField] private Transform faceChecker;
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
            
            if (IsGrounded(groundChecker))
            {
                jumpCount = 0;
                gravity = Vector3.zero;
            }
            
            if (jump)
            {
                if(jumpCount >= JumpMax) return;
                jumpCount++;
                gravity.y += gravityForce * -jumpHigh;
            }
            player.position += gravity * Time.deltaTime;
            
        }

        private bool IsGrounded(Transform checker)
        {
            return Physics.CheckSphere(checker.position, groundCheckerRadius, groundLayer);
        }


        private void MoveCat(Vector2 input)
        {
            if(input == Vector2.zero) return;
            var spin = 1f;
            if (IsGrounded(faceChecker))
                spin *= -1f;
            
            player.position += transform.forward * spin * movingSpeed * Time.deltaTime;
            if(jumpCount > 0 && jumpCount < 3) return;
            player.RotateAround(player.position, Vector3.up, rotationSpeed * input.x * Time.deltaTime);
        }


        private void OnDestroy()
        {
            actions.Disable();
        }
    }
}