using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    private GameObject _player;

    public float Speed;
    public float Damage = 15f;

    private bool _isAtack = false;

    public float FlyTime;
    public float TimeWait;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(_player.transform);

        if (_isAtack)
        {
            StartCoroutine(Attack());
        }
        else
        {
            StartCoroutine(MoveUp());
        }
    }

    private IEnumerator MoveUp()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
        yield return new WaitUntil(() => transform.position.y > 2.1);
        _isAtack = true;
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(TimeWait);

        transform.Translate(Vector3.forward * (Speed + 3) * Time.deltaTime);
        yield return new WaitUntil(() => transform.position != _player.transform.position);

        _isAtack = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        
        if(other.transform.tag != "Enemy" && other.transform.tag != "GameController")
        {
            Destroy(gameObject);
        }
    }
}
