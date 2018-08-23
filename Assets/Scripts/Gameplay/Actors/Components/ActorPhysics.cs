using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPhysics : MonoBehaviour {

    private Transform _transform;

    public AxisMovement HorizontalMovement { get; private set; }
    public AxisMovement VerticalMovement { get; private set; }
    public AxisMovement DepthMovement { get; private set; }

    private Vector3 _velocity;

    [SerializeField]
    private float gravityFactor;

    void Awake()
    {
        _transform = transform.parent;

        HorizontalMovement = new AxisMovement(Vector3.right, _transform);
        VerticalMovement = new AxisMovement(Vector3.up, _transform);
        DepthMovement = new AxisMovement(Vector3.forward, _transform);

        _velocity = Vector3.zero;
    }

    // Use this for initialization
    void Start () {
        
    }

    // parent actor calls this
    public void UpdatePhysics()
    {
        HorizontalMovement.UpdateVelocity();
        VerticalMovement.UpdateVelocity();
        DepthMovement.UpdateVelocity();

        _velocity.Set(HorizontalMovement.Velocity, VerticalMovement.Velocity, DepthMovement.Velocity);

        _transform.Translate(_velocity * Time.deltaTime, Space.World);
    }

    #region EVENTS

    public delegate void PhysicsEvent();
    public PhysicsEvent OnGrounded;
    public PhysicsEvent OnAirborne;

    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            if (value != _isGrounded)
            {
                if (value)
                {
                    ExecuteOnGrounded();
                }
                else
                {
                    ExecuteOnAirborne();
                }
                _isGrounded = value;
            }
        }
    }
    [SerializeField] // monitor in inspector
    private bool _isGrounded;

    void ExecuteOnGrounded()
    {
        if (OnGrounded != null)
        {
            OnGrounded();
        }
    }

    void ExecuteOnAirborne()
    {
        if (OnAirborne != null)
        {
            OnAirborne();
        }
    }

    #endregion
}



public class AxisMovement
{
    public float Velocity { get { return _velocity; } }
    public Vector3 VelocityVector { get { return _velocity * _direction; } }

    private Vector3 _direction;
    public float _velocity;
    private float _step;

    private float _targetVelocity;
    private bool _isTargetingTransform;
    private Transform _transform;
    private Transform _targetTransform;
    private Vector3 _targetOffset;

    public AxisMovement(Vector3 direction, Transform transform)
    {
        _direction = direction.normalized;
        _velocity = 0f;
        _step = 0f;

        _targetVelocity = 0f;
        _transform = transform;
        _isTargetingTransform = false;
        _targetOffset = Vector3.zero;
    }

    public void UpdateVelocity()
    {
        if (_velocity != _targetVelocity && _step != 0f)
        {
            if (_isTargetingTransform)
                _velocity = Mathf.MoveTowards(_velocity, Vector3.Scale(_targetTransform.position - _transform.position, _direction).magnitude, _step * Time.deltaTime);
            else
                _velocity = Mathf.MoveTowards(_velocity, _targetVelocity, _step * Time.deltaTime);
        }  
    }

    public void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }

    public void SetStep(float step)
    {
        _step = step;
    }

    public void SetTargetVelocity(float target)
    {
        _isTargetingTransform = false;
        _targetVelocity = target;
    }

    public void SetTargetTransform(Transform target, Vector3 targetOffset)
    {
        _isTargetingTransform = true;
        _targetTransform = target;
        _targetOffset = targetOffset;
    }
}