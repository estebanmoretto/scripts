using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXcretaor : MonoBehaviour {

   //crear pool de sparks y stars
   //
   //
   //
   //
   //

    public GameObject shootFX;
    public GameObject stars;
    public GameObject Orangestars;
    public GameObject sparks;
    public Vector3 moreY = new Vector3(0, 1, 0);

    public Transform meteorContainer;
    private Pool<MeteorRock> pool;
    private Pool<MeteorRock> pool1;
    private Pool<MeteorRock> pool2;
    private Pool<MeteorRock> pool3;
    private Pool<MeteorRock> pool4;
    private Pool<MeteorRock> pool5;


    public MeteorRock MeteorPart1;
    public MeteorRock MeteorPart2;
    public MeteorRock MeteorPart3;
    public MeteorRock MeteorPart4;
    public MeteorRock MeteorPart5;
    public MeteorRock MeteorPart6;
    void Start()
    {

        EventManager.Instance.Subscrive(EventManager.EventID.MeteorDestroy, MeteorDestroyEffect);
        EventManager.Instance.Subscrive(EventManager.EventID.ShootEffect, ShootEffect);
        EventManager.Instance.Subscrive(EventManager.EventID.RockDestroy, RockDestroy);

        pool = new Pool<MeteorRock>(5, GetMeteor, OnReleaseMeteor, OnGetMeteor);
        pool1 = new Pool<MeteorRock>(5, GetMeteor1, OnReleaseMeteor, OnGetMeteor);
        pool2 = new Pool<MeteorRock>(5, GetMeteor2, OnReleaseMeteor, OnGetMeteor);
        pool3 = new Pool<MeteorRock>(5, GetMeteor3, OnReleaseMeteor, OnGetMeteor);
        pool4 = new Pool<MeteorRock>(5, GetMeteor4, OnReleaseMeteor, OnGetMeteor);
        pool5 = new Pool<MeteorRock>(5, GetMeteor5, OnReleaseMeteor, OnGetMeteor);

    }


    void Update()
    {

    }

    private void OnReleaseMeteor(MeteorRock meteor)
    {
        meteor.gameObject.SetActive(false);
        meteor.OnDeath -= pool.ReleaseObject;
    }

    private void OnGetMeteor(MeteorRock meteor)
    {
        meteor.gameObject.SetActive(true);
        meteor.OnDeath += pool.ReleaseObject;
    }

    private MeteorRock GetMeteor()
    {
        var meteor = Instantiate(MeteorPart1);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }
    private MeteorRock GetMeteor1()
    {
        var meteor = Instantiate(MeteorPart2);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }
    private MeteorRock GetMeteor2()
    {
        var meteor = Instantiate(MeteorPart3);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }
    private MeteorRock GetMeteor3()
    {
        var meteor = Instantiate(MeteorPart4);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }
    private MeteorRock GetMeteor4()
    {
        var meteor = Instantiate(MeteorPart5);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }
    private MeteorRock GetMeteor5()
    {
        var meteor = Instantiate(MeteorPart6);
        meteor.transform.parent = meteorContainer;
        meteor.gameObject.SetActive(false);
        return meteor;
    }

    private void ShootEffect(GameObject e)
    {
        Instantiate(shootFX, e.transform.position, e.transform.rotation);
    }

    private void RockDestroy(GameObject e)
    {
      //  Instantiate(stars, e.transform.position, e.transform.rotation);
        Instantiate(sparks, e.transform.position, e.transform.rotation);
    }

    private void MeteorDestroyEffect(GameObject e)
    {
        //Instantiate(Orangestars, e.transform.position, e.transform.rotation);
        //Instantiate(sparks, e.transform.position, e.transform.rotation);

        Instantiate(stars, e.transform.position, e.transform.rotation);
        Instantiate(sparks, e.transform.position, e.transform.rotation);

        MeteorRock meteor = pool.GetObject();
        meteor.Spawn(e.transform.position, e.transform.rotation);

        MeteorRock meteor1 = pool1.GetObject();
        meteor1.Spawn(e.transform.position, e.transform.rotation);

        MeteorRock meteor2 = pool2.GetObject();
        meteor2.Spawn(e.transform.position, e.transform.rotation);

        MeteorRock meteor3 = pool3.GetObject();
        meteor3.Spawn(e.transform.position, e.transform.rotation);

        MeteorRock meteor4 = pool4.GetObject();
        meteor4.Spawn(e.transform.position, e.transform.rotation);

        MeteorRock meteor5 = pool5.GetObject();
        meteor5.Spawn(e.transform.position, e.transform.rotation);
    }

  

}

