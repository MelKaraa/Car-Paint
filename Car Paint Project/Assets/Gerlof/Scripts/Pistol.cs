using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;


public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;
    [SerializeField] int bullets;
    [SerializeField] int maxBullets;
    [SerializeField] GameObject ReloadUI;

    [SerializeField] InputActionProperty reloadButton;

    private void Start()
    {
        maxBullets = 7;
        bullets = maxBullets;
    }
    private void Update()
    {
        if(reloadButton.action.ReadValue<float>() > 0.1f) 
        {
            Reload();
        }
    }

    public void Reload()
    {
        bullets = maxBullets;
    }
    public void FireBullet()
    {
        if (bullets > 0)
        {
            ReloadUI.SetActive(false);
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = firePoint.forward * fireSpeed;
            Destroy(spawnedBullet, 3f);
            bullets--;
        }
        
        if(bullets <= 0) 
        {
            ReloadUI.SetActive(true);
        }
        
    }
}
