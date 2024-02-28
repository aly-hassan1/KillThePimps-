using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera fpsCam;

    public AudioSource shootingSound;
    public AudioSource emptyGunShot;
    public AudioSource reloadingSound;
    public ParticleSystem mozzelEffect;
    public GameObject impactEffect;


    [SerializeField] private float bulletRange;
    [SerializeField] private float fireRate, reloadTime;
    [SerializeField] private bool isAutomatic;
    [SerializeField] private int magazineSize;
    private Animation anim;
    public Animator animator;
    public int ammoLeft;
    public bool isShooting, readyToShoot, reloading;
    [SerializeField] private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        ammoLeft = magazineSize;
        readyToShoot = true;

        anim = GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
        uiManager = GameObject.Find("A7A").GetComponent<UIManager>();
        animator.SetBool("idle", true);

    }

    // Update is called once per frame
    void Update()
    {

        if (isShooting && readyToShoot && !reloading && ammoLeft > 0)
        {
            PerformShot();
        }
        else if (isShooting && readyToShoot && !reloading && ammoLeft == 0)
        {
            EmptyGunShot();

        }
    }
    public void StartShot()
    {
        isShooting = true;

    }
    public void EndShot()
    {
        isShooting = false;
    }
    private void PerformShot()
    {
        readyToShoot = false;

        Ray ray = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, bulletRange))
        {
            
            GameObject impactGo = Instantiate(impactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
            Destroy(impactGo, 2f);
            shootingSound.Play();
            mozzelEffect.Play();

        }
        else
        {
             shootingSound.Play();
             mozzelEffect.Play();
             GameObject impactGo = Instantiate(impactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
             Destroy(impactGo, 2f);


        }
        ammoLeft--;
        uiManager.UpdateAmmo(ammoLeft);
        if (ammoLeft >= 0)
        {
           Invoke("ResetShot", fireRate);
           if(!isAutomatic)
           {
                EndShot();
           }
        }
      
    }
    private void EmptyGunShot()
    {
        emptyGunShot.Play();
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        reloadingSound.Play();
        reloading = true;
        Invoke("ReloadFinish", reloadTime);
    }
    private void ReloadFinish()
    {
        ammoLeft = magazineSize;
        reloading = false;
        uiManager.UpdateAmmo(ammoLeft);

    }

}
