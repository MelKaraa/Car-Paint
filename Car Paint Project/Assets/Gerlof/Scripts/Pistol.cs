using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using TMPro;


public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;
    [SerializeField] int bullets;
    [SerializeField] int maxBullets;
    [SerializeField] GameObject reloadUI;
    [SerializeField] TMP_Text bulletCounter;

    [SerializeField] InputActionProperty reloadButton;

    private void Start()
    {
        bulletCounter.text = "Bullets: " + bullets;
        bullets = maxBullets;
    }
    private void Update()
    {
        if(reloadButton.action.ReadValue<float>() > 0.1) 
        {
            DoReload();
        }
    }


    IEnumerable Reload()
    {
        yield return new WaitForSeconds(3);
        DoReload();
    }

    void DoReload()
    {
        reloadUI.SetActive(false);
        bullets = maxBullets;
        bulletCounter.text = "Bullets: " + bullets;
    }
   
    public void FireBullet()
    {
        if (bullets > 0)
        {          
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = firePoint.forward * fireSpeed;
            Destroy(spawnedBullet, 3f);
            bullets--;
            bulletCounter.text = "Bullets: " + bullets;
        }        
        else 
        {
            reloadUI.SetActive(true);
        }
        
    }
}
