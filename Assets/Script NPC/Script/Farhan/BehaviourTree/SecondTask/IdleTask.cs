using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class IdleTask : Node
{
    private Transform _transform;
    private PlayerData _playerData;
    private GameObject _player;
    private GameObject _npc;
    private Animator _animator;

    public IdleTask(GameObject player, GameObject npc, Transform transform)
    {
        _player = player;
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {

        _animator.SetBool("BIdle", true);

        state = NodeState.RUNNING;
        return state;
    }

}
