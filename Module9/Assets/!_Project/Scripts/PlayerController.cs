using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ObjectMovement _objectMovement;
    [SerializeField] private ShootAbility _shootAbility;
    [SerializeField] private Animator _animator;

    [SerializeField] private string _moveAnimParameterName = "IsRunning";
    [SerializeField] private string _runSpeedParameterName = "RunSpeed";
    [SerializeField] private string _attackAnimParameterName = "IsAttacking";
    [SerializeField] private string _hitAnimParameterName = "Hit";
    [SerializeField] private string _deathAnimParameterName = "IsDead";
    [SerializeField] private string _idleTag = "Idle";

    public bool CanMove { get; set; }
    public bool CanShoot { get; set; }

    private Vector3 _direction;

    private bool _isShooting = false;
    private bool _isGoingToMove = false;

    private void Start()
    {
        _objectMovement.Setup();
        ApplyIdleState();
        _animator.SetFloat(_runSpeedParameterName, _objectMovement.Speed);
    }

    private void FixedUpdate()
    {
        if (_isShooting)
        {
            _shootAbility.TryShoot(); ;
        }
        if (CanMove)
        {
            _objectMovement.Move(_direction);
        }

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsTag(_idleTag))
        {
            ApplyIdleState();
            if (_isGoingToMove)
            {
                ApplyRunningState();
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction2D = context.ReadValue<Vector2>();
        _direction = new Vector3(direction2D.x, 0, direction2D.y);

        _isGoingToMove = (direction2D != Vector2.zero);

        if (!CanMove)
        {
            return;
        }

        if (context.started || context.performed)
        {
            ApplyRunningState();
        }
        else if (context.canceled)
        {
            ApplyIdleState();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!CanShoot)
        {
            return;
        }
        if (context.started || context.performed)
        {
            ApplyShootingState();
        }
        else if (context.canceled)
        {
            _isShooting = false;
            _animator.SetBool(_attackAnimParameterName, false);
        }
    }

    public void OnReceiveDamage(bool isDead = false)
    {
        if (isDead)
        {
            _animator.SetBool(_deathAnimParameterName, true);
        }
        ApplyDamagedState();
    }

    private void ApplyShootingState()
    {
        CanMove = false;
        _isShooting = true;

        _animator.SetBool(_moveAnimParameterName, false);
        _animator.SetBool(_attackAnimParameterName, true);

        _objectMovement.Stop();
    }

    private void ApplyIdleState()
    {
        CanMove = true;
        CanShoot = true;

        _isShooting = false;

        _animator.SetBool(_moveAnimParameterName, false);
        _animator.SetBool(_attackAnimParameterName, false);

        _objectMovement.Stop();
    }

    private void ApplyRunningState()
    {
        CanMove = true;
        CanShoot = true;

        _isShooting = false;

        _animator.SetBool(_moveAnimParameterName, true);
        _animator.SetBool(_attackAnimParameterName, false);
    }

    private void ApplyDamagedState()
    {
        CanMove = false;
        CanShoot = false;

        _isShooting = false;

        _animator.SetBool(_moveAnimParameterName, false);
        _animator.SetBool(_attackAnimParameterName, false);
        _animator.SetTrigger(_hitAnimParameterName);

        _objectMovement.Stop();
    }
}
