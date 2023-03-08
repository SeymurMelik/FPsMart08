using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    public int Health = 150;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
