using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Referência para o transform do jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    public Vector3 offset; // Distância entre a câmera e o jogador

    [SerializeField] private UnityEngine.Camera cam;
    private BoxCollider2D box;
    private float sizeX, sizeY, ratio;
    private float velocity = 0f;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
        if(target.GetComponent<Player>().isRunnning)
        {
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 4f, ref velocity, 0.25f);
        }
        else
        {
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 3f, ref velocity, 0.25f);
        }

        sizeY = cam.orthographicSize * 2;
        ratio = (float)Screen.width/(float)Screen.height;
        sizeX = sizeY * ratio;
        box.size = new Vector2(sizeX, sizeY);

    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = transform.position.z; // Manter a posição Z da câmera fixa
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Limit"))
    //    {
    //        cameraFix = other.gameObject.transform;
    //    }
            

    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        cameraFix = target;
    //    }
        
    //}

}
