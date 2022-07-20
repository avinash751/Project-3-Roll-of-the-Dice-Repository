using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazzooka : MonoBehaviour
{
    [Header("Graphic")]
    public GameObject MuzzleFlash;
    public GameObject BulletHoleGraphic;

    [Header("Bullet Spawning Related settings")]
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;

    [Header("Gun Shooting  Related settings")]
    public int MagazineSize;
    public int BulletsPerTap;
    public float TimeBetweenShooting;
    public float TimeBetweenShots;
    public float BulletDestroyTimer;
    public float MaxBulletSpread;
    public float MinBulletSpread;
    public float BulletSpeed;
    public float ExplosionSize;


    [Header("Gun Shooting Info")]
    public int CurrentBullets;
    public int BulletsShot;
    public bool ReadyToShoot;
    Vector3 BulletSpread;

    [Header("Camera Shake Settings")]
    public float Magnitude;
    public float Roughness;
    public float FadeInTime;
    public float FadeOutTime;


    [Header("Audio Manager")]
    //public SoundManager AudioManager;
    public string GunShotSound;
    public string GunReloadSound;

    void Start()
    {
       CurrentBullets = MagazineSize;
       ReadyToShoot = true;
       // AudioManager = FindObjectOfType<SoundManager>();
    }


    private void Update()
    {
        InputToshoot();
        DisableWhenAmmoOver();
    }
    void InputToshoot()
    {
        if (Input.GetMouseButtonDown(0)  && CurrentBullets > 0 && ReadyToShoot)
        {
            BulletsShot = BulletsPerTap;
            ProcessForEachBulletShot();
           // PlayGunShotParticleSystems();
            //ShakeCameraOnce();
            //AudioManager.PlayAnAudio(GunShotSound, true);
        }
    }

    void ProcessForEachBulletShot()
    {
        ReadyToShoot = false;
        
        float ySpread = Random.Range(MinBulletSpread, MaxBulletSpread);
        BulletSpread = new Vector3(0, ySpread, 0);
        SpawnBullet();

        BulletsShot--;
        CurrentBullets--;

        if (BulletsShot > 0 && CurrentBullets > 0)
        {
            Invoke("ProcessForEachBulletShot", TimeBetweenShots);
            Debug.Log(BulletsShot);
        }
    }
    void EnableShooting()
    {
        ReadyToShoot = true;
    }

    void SpawnBullet()
    {
        GameObject Duplicate = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        Duplicate.GetComponent<Rigidbody>().AddForce((BulletSpawnPoint.transform.up + BulletSpread) * BulletSpeed);

        Invoke("EnableShooting", TimeBetweenShooting);
        Destroy(Duplicate, BulletDestroyTimer);
    }

    void DisableWhenAmmoOver()
    {
        if(CurrentBullets<=0)
        {
            gameObject.SetActive(false);
        }
    }

    

  
    void PlayGunShotParticleSystems()
    {
        PlayAndDelateAParticleSystem(MuzzleFlash, BulletSpawnPoint, 0.4f);
    }

    void PlayAndDelateAParticleSystem(GameObject particleSysytem, Transform SpawnPoint, float DestroyTimer)
    {
        GameObject duplicate = Instantiate(particleSysytem, SpawnPoint.transform.position, Quaternion.identity);
        Destroy(duplicate, DestroyTimer);
    }

    void ShakeCameraOnce()
    {
        //CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, FadeInTime, FadeOutTime);
        Debug.Log("shake");
    }
}
