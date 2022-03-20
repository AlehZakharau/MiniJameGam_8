using System;
using UnityEngine;

namespace Code
{
    public interface IMilkCollector
    {
        public void AddMilk();
    }

    public class MilkCollector : MonoBehaviour, IMilkCollector
    {
        public event Action onAddingMilk; 
        public void AddMilk()
        {
            onAddingMilk?.Invoke();
        }
    }
}