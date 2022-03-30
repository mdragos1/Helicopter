using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(14, Random.Range(-31f, -21f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-2.5f,0)* Time.deltaTime);
    }
}
