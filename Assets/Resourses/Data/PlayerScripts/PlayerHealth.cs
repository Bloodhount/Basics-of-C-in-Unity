using GB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public sealed class PlayerHealth : BaseHealth, ITakeDamage, ILog  //MonoBehaviour
    {
        [SerializeField] private AudioSource TakeDamageSFX;
        [SerializeField] private AudioSource HealSFX;

        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            TakeDamageSFX.Play();
            Debug.Log( $" {name} - <color=red>Damaged</color>"); 
            if (Health <= 0)
            {
                Health = 0;
                Die();
                Log<string>($"{ name }", " - Die");
            }
        }
        public override void Heal(int healthValue)
        {
            base.Heal(healthValue);
            HealSFX.Play();
            Log<string>($"{name}", " - Heal");
            // Debug.Log($" {name} - Heal");
        }
        public void Log<String>(string name, string msg)
        {
            Debug.Log($" { name } - { msg }");
        }
    }

}
