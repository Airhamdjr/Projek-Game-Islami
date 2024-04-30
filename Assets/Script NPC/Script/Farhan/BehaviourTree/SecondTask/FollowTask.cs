using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class FollowTask : Node
{
    // Start is called before the first frame update
    private static int _playerLayerMask = 1 << 8;

    private Transform _transform;
    private PlayerData _playerData;
    private GameObject _player;
    private GameObject _npc;
    private Animator _animator;

    public FollowTask(PlayerData playerData, GameObject player, GameObject npc, Transform transform)
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

        if (Vector3.Distance(_transform.position, _player.transform.position) > 3f && Vector3.Distance(_transform.position, _player.transform.position) < 10f)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, _player.transform.position, ActionBT.npcRunningSpeed * Time.deltaTime);
            _transform.LookAt(_player.transform.position);

            _animator.SetBool("Running", true);
            _animator.SetBool("Yelling", false);

            state = NodeState.RUNNING;
            return state;
        }
        else if (Vector3.Distance(_transform.position, _player.transform.position) < 3f)
        {
            _transform.LookAt(_player.transform.position);

            _animator.SetBool("Running", false);
            _animator.SetBool("Yelling", true);

            Debug.Log("Nilai Kamu Masih Kurang");

            state = NodeState.RUNNING;
            return state;
        }
        else if (Vector3.Distance(_transform.position, _player.transform.position) > 10f)
        {
            _animator.SetBool("Running", false);
            _animator.SetBool("Yelling", false);

            Debug.Log("Player terlalu Jauh");

            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
