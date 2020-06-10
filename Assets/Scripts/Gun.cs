using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject Bullet;
    public Transform spawnPoint;
    public float force = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
        
    }

    private void Shot()
    {
         GameObject bullet =  Instantiate(Bullet, spawnPoint.position, Quaternion.identity);
         Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
         
         rigidbody.AddForce(spawnPoint.forward * force);
    } 
}
