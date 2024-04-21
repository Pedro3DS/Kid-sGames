using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    private float lenght, startPosition;
    [SerializeField] private GameObject cam;
    [SerializeField] private float paralaxEffect;


    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - paralaxEffect));
        float dist = (cam.transform.position.x * paralaxEffect);

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if(temp > startPosition + lenght)
        {
            startPosition += lenght;
        }
        else if(temp < startPosition - lenght)
        {
            startPosition -= lenght;
        }
    }
}
