using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector]public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioplayer;
    float nextFireTime;

    void Awake()
    {
        audioplayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

  
    void Update()
    {
        if (isFiring && Time.time >= nextFireTime) // Yeni ateþ zamanýna ulaþýldýðýnda ateþ et
        {
            Fire();
            CalculateNextFireTime();
        }
    }
    void CalculateNextFireTime()
    {
        float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
        timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

        nextFireTime = Time.time + timeToNextProjectile;
    }

    void Fire()
    {

        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();   // chatgpt ye yazdýrdýðým kod
        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed;
            audioplayer.PlayShootingClip();
        }

        Destroy(instance, projectileLifetime);
       /* if (isFiring && firingCoroutine == null) 
        {
           firingCoroutine = StartCoroutine(FireContinuously());      //  122. videoda adamýn yazdýgý kod bu kod ile çalýþtýrýnca space e bir defa bastýðýmda sürekli atýþ yapýyor býr daha basýnca kapanýyor.
        }
        else if (isFiring && firingCoroutine != null) 
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }*/

    }

   /* IEnumerator FireContinuously()
    {
        while (true)
        { 
            GameObject instance = Instantiate(projectilePrefab, 
                                              transform.position, 
                                              Quaternion.identity );     //chatgpt bu kýsmý çýkarmýþtý ama ben ekledim sorunsuz çalýþýyor.

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy( instance, projectileLifetime );

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                                      baseFiringRate + firingRateVariance);

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            audioplayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }*/
}
