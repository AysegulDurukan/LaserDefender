using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{   // d��man hasar�n� tutuyor sadece
   
    [SerializeField] int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    
}
