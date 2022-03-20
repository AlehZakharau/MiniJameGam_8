using UnityEngine;

namespace Code
{
    public interface ICheckPointKeeper
    {
        public void NewCheckPoint(Vector3 position);
    }
    public class CheckPointKeeper : MonoBehaviour, ICheckPointKeeper
    {
        public Vector3 CurrentCheckPoint { get; private set; }
        
        public void NewCheckPoint(Vector3 position)
        {
            CurrentCheckPoint = position;
        }
    }
}