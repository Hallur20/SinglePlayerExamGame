using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    public Vector2 velocity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("AI")) {
            Destroy(collision.gameObject);
            Destroy(gameObject); //if a bullet hits an ai, the ai and the bullet is destroyed
        }
        if (collision.gameObject.name.Equals("Platform"))
        {
            Destroy(gameObject); //if bullet hits a platform, the bullet is destroyed
        }
        if (collision.gameObject.name.Contains("Pickup"))
        {
            StartCoroutine(GoThroughPickup(collision));

        }

    }

    // Use this for initialization
    void Start () {
        StartCoroutine(DestroyBulletAfter2Seconds());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyBulletAfter2Seconds() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    IEnumerator GoThroughPickup(Collision2D collision) {
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);
        yield return new WaitForSeconds(0.5F);
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
