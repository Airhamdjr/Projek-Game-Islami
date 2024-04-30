using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class GreetTask : Node
{
    // Start is called before the first frame update
    private static int _playerLayerMask = 1 << 8;

    private Transform _transform;
    private PlayerData _playerData;
    private GameObject _player;
    private GameObject _npc;
    private Animator _animator;

    public GreetTask(PlayerData playerData, GameObject player, GameObject npc, Transform transform)
    {
        _playerData = playerData;
        _player = player;
        _npc = npc;
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    void awake()
    {
        _playerData = _player.GetComponent<PlayerData>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, _player.transform.position) > 0.01f && Vector3.Distance(_transform.position, _player.transform.position) < 5f)
        {
            _transform.LookAt(_player.transform.position);

            _animator.SetBool("Talking", true);
            Debug.Log("Nilai kamu Sangat Bagus");

            state = NodeState.RUNNING;
            return state;
        }
        else if (Vector3.Distance(_transform.position, _player.transform.position) > 5f)
        {
            _animator.SetBool("Talking", false);

            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;

    }
}
