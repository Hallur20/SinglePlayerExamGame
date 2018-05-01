using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {

    bool whichWay = true;
    public float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("StopRight") && whichWay == true) {
            Debug.Log("going left");
            whichWay = false;
          
        }
        if (collision.gameObject.name.Equals("StopLeft") && whichWay == false)
        {
            Debug.Log("going right");
            whichWay = true;
            
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
            gameObject.transform.Translate(new Vector3(0.02F, 0, 0));
        }
        if (whichWay == false) {
            gameObject.transform.Translate(new Vector3(-0.02F, 0, 0));
        }
            

        
    }
}
