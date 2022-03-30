using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopterController : MonoBehaviour
{
    public float force ;
    private Rigidbody2D rigidBody;
    public bool isDead = false;
    private int contor = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false) {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began)
                {
                    print("atins");contor++;
                    rigidBody.AddForce(new Vector2(0, force));

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    print("iau degetu");contor--;
                    //rigidBody.AddForce(new Vector2(0, -5));
                    rigidBody.velocity = new Vector2(0,rigidBody.velocity.y/1.8f);
                    rigidBody.AddForce(new Vector2(0, -((contor*force)/10)));contor = 0;
                }
            }
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Score" && collision.tag !="Destroyer")
        {
            rigidBody.velocity = Vector2.zero;
            isDead = true;
            print("lovit");
            gameController.instance.Crashed();
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            gameController.instance.Scored();
            print("cresc scorul");
        }
    }
}
