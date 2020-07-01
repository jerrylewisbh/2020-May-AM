using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactible
{

    public GameObject Bullet;
    public Transform spawnPoint;
    public float force = 200;

    public override void Interact()
    {
        Debug.Log("Shot");
        Shot();
    }


    private void Shot()
    {
         GameObject bullet =  Instantiate(Bullet, spawnPoint.position, Quaternion.identity);
         Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
         
         rigidbody.AddForce(spawnPoint.forward * force);
    } 
}
