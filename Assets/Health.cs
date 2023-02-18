using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    [SerializeField]
    private int maxHealth = 10;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
