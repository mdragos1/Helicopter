using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopterController : MonoBehaviour
{
    public float force ;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began)
            {
                print("atins");
                force = 1;

            }
            else if (touch.phase == TouchPhase.Ended) { 
                print("iau degetu");
                rigidBody.AddForce(new Vector2(0, -5));
            }
        }
        else
        {
            force = 0;
        }
        rigidBody.AddForce(new Vector2(0, force));
    }
}
