using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Debug;

namespace GB
{
    public sealed class EnemyHealth : BaseHealth, ITakeDamage  //MonoBehaviour
    {
        // private int health = 5;

        private void Start()
        {
            //health = GetComponent<EnemyHealth>().Health;
            // Health = health;
        }
        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            Log($" {name} - Damaged" + $", Health {Health}");
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
        public override void Die()
        {
            Log($"{ name } - Enemy. Die");
            Destroy(gameObject);
        }
    }
}
