using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float maxX = 5f;
    [SerializeField]
    float minX = 5f;
    // Update is called once per frame
    Vector2 pos;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= minX)
        {
            pos  = new Vector2(maxX , transform.position.y);
            transform.position = pos;
        }
    }
}
