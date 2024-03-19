using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 target;
    [SerializeField] Camera playerCamera;

    private void Start()
    {
        target = transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            target = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }

}
