using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour {

    public NormalBullet bulletPrefab;
    public Transform bulletContainer;
    public GameObject bulletSpawner;
    bool canShoot = true;
    private Pool<NormalBullet> pool;
    private AudioSource audioSource;

    void Start()
    {
        pool = new Pool<NormalBullet>(5, GetBullet, OnReleaseBullet, OnGetBullet);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnReleaseBullet(NormalBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.OnDeath -= pool.ReleaseObject;
    }

    private void OnGetBullet(NormalBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.OnDeath += pool.ReleaseObject;
    }

    private NormalBullet GetBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.parent = bulletContainer;
        bullet.gameObject.SetActive(false);
        return bullet;
    }
    public IEnumerator FireRate()
    {
        yield return new WaitForSeconds(0.1f);
        canShoot = true;


    }
    public void Shoot()
    {
        if (canShoot)
        {
            var bullet = pool.GetObject();
            bullet.Spawn(bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            canShoot = false;
            StartCoroutine(FireRate());
            audioSource.Play();
        }
       
    }
}
