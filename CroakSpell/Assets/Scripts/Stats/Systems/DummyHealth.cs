using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DummyHealth : MonoBehaviour
{
    [SerializeField] private float maxLife;
    private float life;
    private void Awake()
    {
        life = maxLife;
    }
    internal void TakeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            DummyDie();
        }
    }
    private void DummyDie()
    {
        Destroy(gameObject);
    }
}
