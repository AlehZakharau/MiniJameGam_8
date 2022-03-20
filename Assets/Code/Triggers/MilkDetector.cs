using UnityEngine;

namespace Code
{
    public class MilkDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMilkCollector collector))
            {
                collector.AddMilk();
                Destroy(gameObject);
            }
        }
    }
}