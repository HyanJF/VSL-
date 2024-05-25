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
    public float minX,minY,maxX, maxY;

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
        if(target.x< minX || target.x> maxX )
        {
            target.x = transform.position.x;    
        }
        if (target.y < minY || target.y > maxY)
        {
            target.y = transform.position.y;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
        animator.SetBool("IsMoving",transform.position!=(Vector3)target);

    }

}
