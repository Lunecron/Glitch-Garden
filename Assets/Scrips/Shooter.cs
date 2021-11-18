using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject gun;
    [SerializeField] float attackspeed = 1f;
    // Start is called before the first frame update
    public void Fire(float damage)
    {
        Projectile newProj = Instantiate(projectile, gun.transform.position, transform.rotation);
        newProj.SetSpeed(newProj.GetSpeed() * attackspeed);
    }
    public float GetAttackSpeed()
    {
        return attackspeed;
    }
}
