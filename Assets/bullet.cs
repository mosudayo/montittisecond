using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int speed = 10;
    public int counter = 0;
    private okane money;

    void Start()
    {
        speed = Random.Range(20, 40);
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        
    GameObject aiueo;
    aiueo = GameObject.Find("tintin");
        money = aiueo.GetComponent<okane>();
}

    void Update()
    {
       if (transform.position.y <= -7.4) {
        if (money.counterherasi()) {  }
        Destroy(gameObject);
        }
    }

}