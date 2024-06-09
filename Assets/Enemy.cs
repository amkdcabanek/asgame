using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Enmy : MonoBehaviour
{
    public int enemyHealth = 10;
    public GameObject projectile;

    public Transform ProjectilePoint;
    public Animator animator;   
    // Start is called before the first frame update

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, ProjectilePoint.position, ProjectilePoint.rotation).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    }
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            animator.SetTrigger("death");
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    
        
    

}
