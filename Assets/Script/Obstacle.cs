using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    int damage = 1;

    [SerializeField]
    int minX;

    [SerializeField]
    GameObject effect;
    [SerializeField]
    GameObject soundEffect;
        


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < minX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(soundEffect , transform.position, Quaternion.identity);
            // from player contoller 
            other.gameObject.GetComponent<PlayerContoller>().HealthContoller(damage);

            Destroy(this.gameObject);
        }
    }

}
