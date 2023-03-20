using UnityEngine;

public class UltGun : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public ParticleSystem ParticleSystem;
    public Animator Animator;

    public float Damage = 1000f;
    public float Range = 1000f;

    public LayerMask EnemyLayers;

    private void Start()
    {
        PlayerStats.CurrentUltPoints = 50f;
    }
    
    public void ShootByButton()
    {
        if (PlayerStats.CurrentUltPoints >= PlayerStats.MaxUltPoints)
        {
            Animator.SetTrigger("UltShot");
        }
    }

    //Animation Event
    private void Shoot()
    {
        ParticleSystem.Play();

        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, Range, EnemyLayers);

        if (hitEnemies.Length > 0)
        {
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHP>().TakeDamage(Damage);
            }
        }

        PlayerStats.CurrentUltPoints = 0f;
    }


}
