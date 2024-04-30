using System.Collections.Generic;
using BehaviourTree;
public class ActionBT : Tree
{
    public UnityEngine.GameObject _player;
    public UnityEngine.GameObject _npc;
    public PlayerData _playerData;
    public static float playerRange = 10f;

    public static float npcWalkingSpeed = 3f; // Adjust this value to set the NPC's speed
    public static float npcRunningSpeed = 7f;

    protected override Node SetupTree()
    {
        //Node root = new IdleTask(_player, _npc, transform);

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInRange(_player, _npc, transform),
                new DefaultTask(_player, _npc, transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckNullData(_playerData, _player, _npc, transform),
                new NullDataTask(_playerData, _player, _npc, transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckBehaviourGreet(_playerData, _player, _npc, transform),
                new GreetTask(_playerData, _player, _npc, transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckBehaviourApproach(_playerData, _player, _npc, transform),
                new ApproachTask(_playerData, _player, _npc, transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckBehaviourFollow(_playerData, _player, _npc, transform),
                new FollowTask(_playerData, _player, _npc, transform),
            }),
            

            new IdleTask(_player, _npc, transform),

        });

        return root;
    }
}
