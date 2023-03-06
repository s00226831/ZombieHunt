using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Player : Character
{
    float h;
    float v;
    Vector3 mouseWorldPosition;

    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;

    public int Ammo = 20;
    public int maxAmmo = 20;
    public float RegenerateAmmoTime = 2;
    public int AmmoRegenAmount = 1;
    protected override void Start()
    {
        InvokeRepeating("RegenerateAmmo", RegenerateAmmoTime, RegenerateAmmoTime);

        base.Start();
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        transform.up = mouseWorldPosition - transform.position;

        if (Input.GetButton("Fire2"))
        {
            SetState(CharacterState.Attack);
            if(Input.GetButtonDown("Fire1"))
            {
                if (Ammo > 1)
                {
                    Fire();
                }
            }
        }
        else
        {
            SetState(CharacterState.Idle);
        }
    }
    private void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3 (h,v,0) * movementSpeed * Time.deltaTime);
    }
    void Fire()
    {
        Instantiate(BulletPrefab, BulletSpawnPoint);
        
        Ammo--;
    }
    void RegenerateAmmo()
    {
        if (Ammo < maxAmmo)
        {
            Ammo += AmmoRegenAmount;
        }
        else if (Ammo > maxAmmo)
        {
            Ammo = maxAmmo;
        }
    }
}
