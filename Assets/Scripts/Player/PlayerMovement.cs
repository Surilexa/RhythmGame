using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class PlayerMovement : MonoBehaviour
{
    MovementInfo movementInfo;
    [SerializeField] private InputActionReference D_key, F_key, J_key, K_key;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private GameObject moveEffect;
    [SerializeField] private Transform moveEffectTarget;

    private int previousPosition = 0;
    private int currentPosition = 0;
    private bool move = true;   

    private float moveDelay = 1;

    [Header("Interpolation")]
    private float moveSpeed = 1;
    private Transform current;
    public Transform target;
    private float sinTime =0;
    void Start()
    {

        current = transform;
        current.position = transform.position;
        if (FindFirstObjectByType<MovementInfo>() != null)
        {
            movementInfo = FindFirstObjectByType<MovementInfo>();
            target.position = movementInfo.MovementLocations[0].position;
        }
        else
        {
            target.position = Vector3.zero;
        }

        
       // Debug.Log(target.position);
    }

    private void Update()
    {
        if (!move)
        {
            var timeStamp = Time.deltaTime + moveDelay;
            if(timeStamp <= Time.deltaTime)
            {
                move = true;
            }
        }

        //this will move the note object down overtime at the speed based on diffictuly.
        if(target.position != null && move)
        {
            TravelToLocation(target.position, previousPosition, currentPosition);
        }
    }

    private void OnEnable()
    {
        D_key.action.performed += PerformedDKey;
        F_key.action.performed += PerformedFKey;
        J_key.action.performed += PerformedJKey;
        K_key.action.performed += PerformedKKey;
    }
    private void OnDisable()
    {
        D_key.action.performed -= PerformedDKey;
        F_key.action.performed -= PerformedFKey;
        J_key.action.performed -= PerformedJKey;
        K_key.action.performed -= PerformedKKey;
    }

    private void PerformedDKey(InputAction.CallbackContext key)
    {
        //Debug.Log("D");
        current.position = transform.position;
        target.position = movementInfo.MovementLocations[0].position;
        previousPosition = currentPosition;
        currentPosition = 0;
        PlayMovementEffect();
    }
    private void PerformedFKey(InputAction.CallbackContext key)
    {
        current.position = transform.position;
        target.position = movementInfo.MovementLocations[1].position;
        previousPosition = currentPosition;
        currentPosition = 1;
        PlayMovementEffect();
    }
    private void PerformedJKey(InputAction.CallbackContext key)
    {
        current.position = transform.position;
        target.position = movementInfo.MovementLocations[2].position;
        previousPosition = currentPosition;
        currentPosition = 2;
        PlayMovementEffect();
    }
    private void PerformedKKey(InputAction.CallbackContext key)
    {
        current.position = transform.position;
        target.position = movementInfo.MovementLocations[3].position;
        previousPosition = currentPosition;
        currentPosition = 3;
        PlayMovementEffect();
    }

    //this will move the player to to a set location based on the key pressed. 
    public void TravelToLocation(Vector3 location, int previousPos, int currentPos)
    {
        if(transform.position != location)
        {
            sinTime += Time.deltaTime * moveSpeed;
            sinTime = Math.Clamp(sinTime, 0, Mathf.PI);
            float t = speedCurve.Evaluate(sinTime);
            transform.position = Vector3.Lerp(current.position, target.position, t);
            //Debug.Log(transform.position);
        }
        //resets the sinTime to replay the animation curve.
        else if(transform.position == location)
        {
            sinTime = 0;
        }
    }
    private void PlayMovementEffect()
    {
        //SoundManager.PlaySound(SoundType.Movement, .5f);
        Instantiate(moveEffect, moveEffectTarget.position, Quaternion.identity);
    }
}
