using System;
using UnityEngine;

namespace Code
{
    public class FallDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IFall fall))
            {
                fall.Fall();
                AudioCenter.Instance.PlaySound(EAudioClips.CatScare);
            }
        }
    }
}