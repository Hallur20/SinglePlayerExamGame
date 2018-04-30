using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomControls : MonoBehaviour {
    bool readyToShoot = true;
    public GameObject bulletClone;
    GameObject bulletSpawn;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Equals("Lava"))
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f") && readyToShoot == true)
        {
            GameObject go = Instantiate(bulletClone);
            Vector3 pos = go.transform.GetComponent<Transform>().position;
            pos.x = pos.x + 1;
            go.transform.position = pos;
            bulletSpawn = go;
            InvokeRepeating("LaunchProjectile", 0.0F, 0.1F);
        }
    }

    void LaunchProjectile() {
        readyToShoot = false;
        if (bulletSpawn != null) //if the server object exists
        {

                bulletSpawn.transform.Translate(1, 0, 0); //move bullet clone +1 x 

            Destroy(bulletSpawn, 1.5F); // destroy bullet clone after 1.5 seconds

        }
        else
        {
            readyToShoot = true;
            CancelInvoke(); //else cancel the invoke and set readyToShoot to true.
        }
    }
}
