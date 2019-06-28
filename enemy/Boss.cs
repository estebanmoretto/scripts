using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public GameObject target;
    public Rigidbody rb;
    public int life=100;
    private bool _attacktime;
    private bool _attack=true;
    public GameObject bulletSpawner1;
    public GameObject bulletSpawner2;
    public GameObject bulletSpawner3;
    public GameObject bulletSpawner4;

    public GameObject laserSword;
    public GameObject laserSword2;
    public GameObject laserSword3;
    public GameObject laserSword4;


    public List<Transform> waypoints = new List<Transform>();

    public BossBullet bulletPrefab;
    private Pool<BossBullet> pool;
    public Transform bulletContainer;
    public GameObject MoveCenter;
    public float speed = 100;
    private bool move = false;
    private int w;

    public float timer;
    void Start ()
    {
        pool = new Pool<BossBullet>(5, GetBullet, OnReleaseBullet, OnGetBullet);
        transform.forward = MoveCenter.transform.position - transform.position;
        rb.AddForce(transform.forward * 200, ForceMode.Impulse);
        _attacktime = true;
    }
	
	
	void Update ()
    {
        transform.GetChild(0).transform.Rotate(0, 2, 0);

        CheckLife();
       /* if (Input.GetKeyDown(KeyCode.I))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            move = true;
            w = GetRandom();
        }*/
        if (_attack == true)
        {
            if (GetRandom() <= 1)
            {


                StartCoroutine(waitAttack());
                _attack = false;
            }else if (GetRandom() >= 1)
            {
                move = true;
                StartCoroutine(waitAttack());
                _attack = false;
            }
           

        }


    }
    private void FixedUpdate()
    {

        if (move == true)
        {
            SpinAttack();
            ChooseWaypoint(w);
        }
    }

    private void OnReleaseBullet(BossBullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.OnDeath -= pool.ReleaseObject;
    }

    private void OnGetBullet(BossBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.OnDeath += pool.ReleaseObject;
    }

    private BossBullet GetBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.parent = bulletContainer;
        bullet.gameObject.SetActive(false);
        return bullet;
    }
    public IEnumerator AttackRate()
    {
        yield return new WaitForSeconds(0.5f);
        _attacktime = true;


    }
    public IEnumerator waitAttack()
    {
        yield return new WaitForSeconds(5f);
        _attack = true;


    }
    void Shoot()
    {
        if (_attacktime)
        {
            var bullet = pool.GetObject();
            bullet.Spawn(bulletSpawner1.transform.position, bulletSpawner1.transform.rotation);
            _attacktime = false;
            StartCoroutine(AttackRate());
            
        }
        laserSword.gameObject.SetActive(false);
        laserSword2.gameObject.SetActive(false);
        laserSword3.gameObject.SetActive(false);
        laserSword4.gameObject.SetActive(false);
    }
    void CheckLife()
    {
        if (life <= 0)
            SceneManager.LoadScene("Win");
    }

    void SpinAttack()
    {
        
        laserSword.gameObject.SetActive(true);
        laserSword2.gameObject.SetActive(true);
        laserSword3.gameObject.SetActive(true);
        laserSword4.gameObject.SetActive(true);
    }
    void ChooseWaypoint(int w)
    {
        transform.forward = waypoints[w].transform.position - transform.position;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
       
    }
    int GetRandom()
    {
        int random = Random.Range(0, 3);
        return random;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            life -= 10;
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 14)
            move = false;
    }

}
