using UnityEngine;

namespace Code
{
    public interface IFall
    {
        public void Fall();
    }

    public class FallComponent : MonoBehaviour, IFall
    {
        [SerializeField] private CheckPointKeeper checkPointKeeper;
        public void Fall()
        {
            transform.position = checkPointKeeper.CurrentCheckPoint;
            transform.rotation = Quaternion.identity;
        }
    }

}