using UnityEngine;

namespace Code
{
    public class MouseDetector : MonoBehaviour
    {
        [SerializeField] private GameObject mouse;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IMouseCollector mouseCollector))
            {
                mouseCollector.EatMouse();
                Destroy(mouse);
            }
        }
    }
}