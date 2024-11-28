using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class BryanController : MonoBehaviour
{
    public BryanStateMachine stateMachine;
    public NavMeshAgent nav_mesh_agent;
    protected Animator animator;

    [SerializeField] public GameObject player;
    public GameObject guardPosition;
    private void Start()
    {
        BryanNeutralState neutral = new BryanNeutralState(this, animator);
        BryanActivatedState activated = new BryanActivatedState(this, animator, nav_mesh_agent);
        BryanAttackState attack = new BryanAttackState(this, animator, nav_mesh_agent);
        stateMachine = new BryanStateMachine(neutral, activated, attack);

        stateMachine.current_state = neutral;
        stateMachine.current_state.EnterState();
    }

    private void Update()
    {
        stateMachine.UpdateCurrentState();
    }
}
