using System;
using UnityEngine;

namespace Code
{
    public class CheckPointDetector : MonoBehaviour
    {
        [SerializeField] private Transform checkPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICheckPointKeeper keeper))
            {
                keeper.NewCheckPoint(checkPoint.position);
            }
        }
    }
}