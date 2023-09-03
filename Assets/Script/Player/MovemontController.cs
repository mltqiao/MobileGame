using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovemontController : MonoBehaviour
{
    public static Vector3 V3TargetDirection;
    public Transform transPlayer;
    public float maxSpeed;
    public float acceleration;
    private float _speedAccelerateTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!transPlayer)
        {
            transPlayer = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (V3TargetDirection != Vector3.zero)
        {
            _speedAccelerateTimer += Time.deltaTime;
            MoveTowardsTargetDirection(V3TargetDirection);
        }
        else
        {
            if (_speedAccelerateTimer != 0)
            {
                _speedAccelerateTimer = 0;
            }
        }
    }

    private void MoveTowardsTargetDirection(Vector3 targetDirection)
    {
        transPlayer.GetComponent<Rigidbody>().velocity = AcceleratedSpeed(_speedAccelerateTimer) * targetDirection;
    }

    private float AcceleratedSpeed(float accelerateDeltaTime)
    {
        var speed = accelerateDeltaTime * acceleration;
        return speed;
    }
}
