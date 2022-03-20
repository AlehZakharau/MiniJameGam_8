using System;
using UnityEngine;

namespace Code
{
    public interface IMouseCollector
    {
        public void EatMouse();
    }
    public class MouseCollector : MonoBehaviour, IMouseCollector
    {
        public event Action onEatingMouse;

        public void EatMouse()
        {
            onEatingMouse?.Invoke();
        }
    }
}