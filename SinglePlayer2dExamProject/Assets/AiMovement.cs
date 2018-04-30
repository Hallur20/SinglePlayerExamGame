using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {

    bool whichWay = true;
    public float speed;

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Stop") && whichWay == true) {
            whichWay = false;
            yield return new WaitForSeconds(1);
        }
        if (collision.gameObject.name.Equals("Stop") && whichWay == false)
        {
            whichWay = true;
            yield return new WaitForSeconds(1);
        }
        if (collision.gameObject.name.Equals("CharacterRobotBoy")) {
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (whichWay == true) {
            gameObject.transform.Translate(new Vector3(0.1F, 0, 0));
        }
        if (whichWay == false) {
            gameObject.transform.Translate(new Vector3(-0.1F, 0, 0));
        }
            

        
    }
}
