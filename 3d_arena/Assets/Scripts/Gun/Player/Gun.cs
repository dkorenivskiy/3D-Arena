using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera Camera;
    public ParticleSystem ParticleSystem;
    public Animator Animator;

    public float Damage = 50f;
    public float Range = 100f;

    public void Shoot()
    {
        Animator.SetTrigger("Shot");
        ParticleSystem.Play();

        RaycastHit hit;
        if(Physics.Raycast(transform.position, Camera.transform.forward, out hit, Range))
        {
            EnemyHP enemyHP = hit.transform.GetComponent<EnemyHP>();
            if(enemyHP != null)
            {
                enemyHP.TakeDamage(Damage);
            }
        }
    }
}
