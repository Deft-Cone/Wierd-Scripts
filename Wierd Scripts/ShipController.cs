using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private InputManager input;

    [Header("References")]
    //[SerializeField] private Camera mainCamera;
    //public Transform playerModel;
    //public Transform aimTarget;
    //public Transform aimLocation;
    private TrailRenderer tr;

    [Header("Movement")]
    //private float horizontalInput;
    //private float verticalInput;
    //private Vector3 moveDirection;
    [SerializeField] private Vector3 _OnRailMoveDirection;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private bool canDodge = true;
    [SerializeField] private bool isDodging;

    [Header("Dash Settings")]
    [SerializeField] private float dodgeSpeed = 20f;
    [SerializeField] private float dodgeDuration = 1f;
    [SerializeField] private float dodgeCooldown = 1f;
    //[SerializeField] private float lookSpeed;



    //float objectWidth;
    //float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        canDodge = true;
        //objectWidth = transform.GetComponent<BoxCollider>().bounds.size.x;
        //objectHeight = transform.GetComponent<BoxCollider>().bounds.size.y;

        input.OnRailMoveEvent += HandleOnRailMove;
        input.RailDodgeEvent += HandleRailDodge;
        //input.RailDodgeCanceledEvent += HandleCancelledRailDodge;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckInput();
        //Movement();
        //RotationLook();
        RailMovement();
        if (isDodging && canDodge)
        {
            StartCoroutine(RailDodge());
        }

    }

    private void CheckInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
    }

    private void Movement()
    {
        transform.localPosition += (moveDirection) * moveSpeed * Time.deltaTime;
        //transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        ClampPosition();
    }

    private void HandleOnRailMove(Vector2 dir)
    {
        _OnRailMoveDirection = dir;
        _OnRailMoveDirection.Normalize();
    }

    private void RailMovement()
    {
        if (_OnRailMoveDirection == Vector3.zero)
        {
            return;
        }

        transform.localPosition += new Vector3(_OnRailMoveDirection.x * moveSpeed, _OnRailMoveDirection.y * moveSpeed, 0) * Time.deltaTime;
        ClampPosition();
    }

    private void HandleRailDodge()
    {
        isDodging = true;
    }

    private void HandleCancelledRailDodge()
    {
        isDodging = false;
    }

    private IEnumerator RailDodge()
    {
        tr.emitting = true;
        transform.localPosition += new Vector3(_OnRailMoveDirection.x * dodgeSpeed, _OnRailMoveDirection.y * dodgeSpeed, 0) * Time.deltaTime;
        yield return new WaitForSeconds(dodgeDuration);
        isDodging = false;
        tr.emitting = false;

        yield return new WaitForSeconds(dodgeCooldown);
        canDodge = true;
    }

    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook()
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(horizontalInput, verticalInput, 1f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Rad2Deg * lookSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.transform.position, 1f);

        Gizmos.color = Color.cyan;
    }
}
