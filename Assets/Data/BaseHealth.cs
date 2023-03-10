
using UnityEngine;

namespace GB
{
    public abstract class BaseHealth : MonoBehaviour, IDeath
    {
        [SerializeField] public int Health { get; protected set; } = 2;
        [SerializeField] public int MaxHealth { get; protected set; } = 5;
        public virtual (int currentHP, int maxHP) GetHP()
        {
            Debug.Log("BaseHealth-GetHP " + Health + ", " + MaxHealth);
            return (Health, MaxHealth);
        }
        public virtual void Heal(int healthValue)
        {
            //(int currentHP, int maxHP) Hp = GetHP();

            Debug.Log($" {name} - BaseHealth.Heal. virtual void Heal");
            Health += healthValue;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
                // Hp.currentHP = Hp.maxHP;
                Debug.Log($" {name} - No treatment is required. \nMaximum health value!");
            }
        }
        public virtual void Die()
        {
            Debug.Log($" {name} - Die. BaseHealth");
        }
    }
}
