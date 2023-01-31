
using UnityEngine;
//using UnityEngine.Events;

namespace GB
{
    public abstract class BaseHealth : MonoBehaviour
    {
        [SerializeField] public int Health { get; protected set; } = 3;
        [SerializeField] public int MaxHealth { get; } = 5;

        // [SerializeField] private UnityEvent _eventOnTakeDamage;

        //  ToDo    interface IDie     { }

        public virtual void Heal(int healthValue)
        {
            Debug.Log($" {name} - Heal");
            Health += healthValue;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
                Debug.Log($" {name} - No treatment is required. \nMaximum health value!");
            }
        }
        public void Die()
        {
            Debug.Log($" {name} - Die");
        }
    }
}
