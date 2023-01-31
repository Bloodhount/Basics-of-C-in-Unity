using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GB
{
    public abstract class BaseHealth : MonoBehaviour
    {
        [SerializeField] public int Health { get; protected set; } = 3;
        [SerializeField] public int MaxHealth { get; } = 5;

        // [SerializeField] private UnityEvent _eventOnTakeDamage;

        //  ToDo    interface ITakeDamage       {  }
        //  ToDo    interface IDie     { }
        //public virtual void TakeDamage(int damageValue)
        //{
        //    Health -= damageValue;
        //    if (Health <= 0)
        //    {
        //        Health = 0;
        //        Die();
        //    }
        //}
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
        public void ShowInfo()
        {
            //  ToDo   remake
            Debug.Log($" {name} - " + GetType().Name + $"health: {Health}");
        }
        // abstract class
        /*
         *         void Start()
        {

        }
        void Update()
        {

        }*/
    }
}
