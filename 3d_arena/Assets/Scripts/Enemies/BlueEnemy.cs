using System.Collections;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackCooldown = 3f;
    private bool _isShoted = false;

    private Transform _player;

    public GameObject Bullet;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        LookAtPlayer();

        if (!_isShoted)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _isShoted = true;
        Instantiate(Bullet, AttackPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(AttackCooldown);
        _isShoted = false;
    }

    private void LookAtPlayer()
    {
        Vector3 target = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        transform.LookAt(target);
    }
}
