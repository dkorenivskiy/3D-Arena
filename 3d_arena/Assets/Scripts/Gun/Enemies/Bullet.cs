using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rb;

    public float UltDamage = 25f;

    public float Speed = 10f;

    private bool _playerTeleported = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction;
        if (_playerTeleported)
        {
            direction = _player.GetComponent<PlayerMovement>().LastPosition;
        }
        else
        {
            direction = _player.transform.position - transform.position;
            _playerTeleported = _player.GetComponent<PlayerMovement>().IsTeleported;
            _player.GetComponent<PlayerMovement>().IsTeleported = false;
        }

        if(transform.position == direction)
        {
            Destroy(gameObject);
        }

        _rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerStats>().TakeUltPointsDamage(25f);
            Destroy(gameObject);
        }

        if (other.transform.tag != "Enemy" && other.transform.tag != "GameController")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "GameController")
        {
            Destroy(gameObject);
        }
    }
}
