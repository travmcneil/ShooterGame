using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed variable of laser
    [SerializeField]
    private float _laserSpeed = 8f;
    

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        transform.Translate(Vector3.up *  _laserSpeed * Time.deltaTime);

        //if lazer is position on the y is greater 8
        //destroy laser
        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
