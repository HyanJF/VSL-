using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    private Vector2 target;
    [SerializeField] Camera playerCamera;
    public Animator animator;

    private void Start()
    {
        target = transform.position;
        speed = Stats.instance.Speed();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            target = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        animator.SetBool("IsMoving",transform.position!=(Vector3)target);

    }

}
