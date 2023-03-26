using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private Transform m_player;
    private StateHandler stateMachine;

    [SerializeField] private string m_currentState; //Only placing this here for visibility in inspector
    [Tooltip("A gameObject on the monster for raycast start position")]
    [SerializeField] private Transform m_eyes;
    [Space]
    [SerializeField] private float m_movementSpeed = 4f;
    [Tooltip("The distance at which the monster will start chasing the player")]
    [SerializeField] private float m_triggerChaseDistance = 5f;
    [Tooltip("The distance at which the monster will stop chasing the player once chasing")]
    [SerializeField] private float m_chaseDistance = 5f;
    [Space]
    [Tooltip("The distance at which the monster will stop to attack the player")]
    [SerializeField] private float m_attackRange = 3f;
    [Tooltip("The cooldown between attacks")]
    [SerializeField] private float m_attackCooldown = 5f;
    [Tooltip("After attacking, the time until the monster can start moving again")]
    [SerializeField] private float m_postAttackMovementCooldown = 2f;
    private float m_timeToNextAttack;

    #region 
    public NavMeshAgent Agent => m_agent;
    public Transform Player => m_player;
    public Transform Eyes => m_eyes;
    
    public float MovementSpeed => m_movementSpeed;
    public float TriggerChaseDistance => m_triggerChaseDistance;
    public float ChaseDistance => m_chaseDistance;

    public float AttackRange => m_attackRange;
    public float AttackCooldown => m_attackCooldown;
    public float TimeToNextAttack => m_timeToNextAttack;
    public float PostAttackMovementCooldown => m_postAttackMovementCooldown;
    #endregion

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.stoppingDistance = 1f;
    }

    private void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;

        stateMachine = new StateHandler(this);
    }

    private void Update()
    {
        stateMachine.HandleStateMachine();
        m_currentState = stateMachine.currentState.ToString();
        m_timeToNextAttack -= Time.deltaTime;
    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position + Vector3.up, m_player.position);
    }

    public void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnAttack()
    {
        Debug.Log(gameObject.name + " is attacking player");
        m_timeToNextAttack = m_attackCooldown;
    }
}
