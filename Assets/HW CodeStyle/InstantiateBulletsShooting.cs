using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenShooting;
    [SerializeField] private Transform _shootingAim;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isShooting = true;
        var waitForSeconds = new WaitForSeconds(_timeBetweenShooting);

        while (isShooting)
        {
            var shootingDirection = (_shootingAim.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + shootingDirection, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = shootingDirection;
            newBullet.GetComponent<Rigidbody>().velocity = shootingDirection * _speed;

            yield return waitForSeconds;
        }
    }
}