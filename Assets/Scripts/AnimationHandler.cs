using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;
    private static AnimationHandler _instance;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if(_instance == null)
        {
            _instance = this;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (JoystickHandler.Direction != Vector2.zero)
        {
            Play(States.Run);
        }
        else
        {
            Play(States.Idle);
        }
    }

    private void Play(States state)
    {  
        if (_animator.GetInteger("State") != (int)state)
        {
            _animator.SetInteger("State", (int)state);
        }
    }

    public static void Mow()
    {
        _instance.Play(States.Mow);
    }

    enum States
    {
        Idle,
        Run,
        Mow
    }
}
