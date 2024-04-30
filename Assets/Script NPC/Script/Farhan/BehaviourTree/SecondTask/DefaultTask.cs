using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class DefaultTask : Node
{
    // Start is called before the first frame update
    private static int _playerLayerMask = 1 << 8;

    private Transform _transform;
    private PlayerData _playerData;
    private GameObject _player;
    private GameObject _npc;
    private Animator _animator;

    public DefaultTask(GameObject player, GameObject npc, Transform transform)
    {
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

        if (Vector3.Distance(_transform.position, _player.transform.position) > 15f && Vector3.Distance(_transform.position, _player.transform.position) < 15f)
        {
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
