using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(JoystickHandler.Direction==Vector2.zero)
        {
            Play(States.Idle);
        }
        else
        {
            Play(States.Run);
        }
    }

    private void Play(States state)
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName(state.ToString()))
        {
            print("Start " + state.ToString());
            _animator.SetInteger("State", (int)state);
        }
    }

    enum States
    {
        Idle,
        Run
    }
}
