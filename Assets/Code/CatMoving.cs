using System;
using UnityEngine;

namespace Code
{
    public class CatMoving : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float speed;
        private Actions actions;


        private void Start()
        {
            actions = new Actions();
            actions.Enable();
        }


        private void Update()
        {
            var input = actions.Payer.Moving.ReadValue<Vector2>();

            MoveCat(input);
        }


        private void MoveCat(Vector2 input)
        {
            var newPosition = new Vector3(input.x, 0, input.y);
            player.transform.position += newPosition * speed * Time.deltaTime;

            var a = player.transform.position + newPosition;
            player.transform.LookAt(a);
        }


        private void OnDestroy()
        {
            actions.Disable();
        }
    }
}