using GB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public sealed class PlayerHealth : BaseHealth, ITakeDamage   //MonoBehaviour
    {

        [SerializeField] private AudioSource TakeDamageSFX;
        [SerializeField] private AudioSource HealSFX;
        //public PlayerHealth(int health)
        //{
        //    Health = health;
        //    //  base.Health = health;
        //}
        //void Start()
        //{
        //    TakeDamageSFX = GetComponent<AudioSource>();
        //    HealSFX = GetComponent<AudioSource>();
        //}
        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            TakeDamageSFX.Play();
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            //Debug.Log($" {name} - Heal");
        }
        public override void Heal(int healthValue)
        {
            base.Heal(healthValue);
            HealSFX.Play();
        }
        //void Update()
        //{

        //}
    }

}
