using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour {

    public GameObject projectile;
    public Vector2 velocity;
    public Text countText;
    public Text winText;
    private int count;

    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4F, 0.1F);
    public float cooldown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Lava")) {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Pick Up"))
        {
            collision.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }



    // Use this for initialization
    void Start () {
        winText.text = "";
        count = 0;
        SetCountText();

    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 2) {
            winText.text = "You win!";
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && canShoot) {
            GameObject go = (GameObject) Instantiate(projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);

        }
    }

    IEnumerator CanShoot() {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
