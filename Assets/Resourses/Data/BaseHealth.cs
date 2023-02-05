
using UnityEngine;

namespace GB
{
    public abstract class BaseHealth : MonoBehaviour, IDeath
    {
        [SerializeField] public int Health { get; protected set; } = 3;
        [SerializeField] public int MaxHealth { get; protected set; } = 5;

        public virtual void Heal(int healthValue)
        {
            Debug.Log($" {name} - BaseHealth.Heal");
            Health += healthValue;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
                Debug.Log($" {name} - No treatment is required. \nMaximum health value!");
            }
        }
        public virtual void Die()
        {
            Debug.Log($" {name} - Die. BaseHealth");
        }
    }
}
