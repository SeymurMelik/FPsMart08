using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
