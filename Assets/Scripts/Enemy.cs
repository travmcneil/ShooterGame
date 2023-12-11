using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-11f, 11f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if bottom of screen
        //respawn at top with a new random x position
        if (transform.position.y < -5F)
        {
            float randomX = Random.Range(-11f, 11f);
            transform.position = new Vector3(randomX, 7, 0);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if other is Player

        if (other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            
            //Destroy us
            Destroy(this.gameObject);
        }


        //if other is laser
        //destroy laser
        //destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
