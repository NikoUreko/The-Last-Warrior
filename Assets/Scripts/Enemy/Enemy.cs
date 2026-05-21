using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player;}
    public Path path;
    [Header ("Sight Value")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header ("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]
    public float fireRate;
    //for debugging
    [SerializeField]
    private string currentState;

    [SerializeField] private int HP = 100;
    private Animator animator;
    private bool isDead = false;

    public GameObject ammoDropPrefab; // prefab peluru yang akan dijatuhkan
    public Transform dropPoint;       // posisi jatuh (bisa posisi musuh atau child transform)


    public AudioSource enemyWalk;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

    bool isWalking = agent.velocity.magnitude > 0.1f;
    animator.SetBool("isWalking", isWalking);

    if (isWalking)
    {
        if (!enemyWalk.isPlaying)
        {
            enemyWalk.loop = true;
            enemyWalk.Play();
        }
    }
    else
    {
        if (enemyWalk.isPlaying)
        {
            enemyWalk.Stop();
        }
        
        if (PlayerHealth.Instance.isDead)
        {
            agent.isStopped = true;
            enemyWalk.Stop();
        }
    }

        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }




    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        HP -= damageAmount;

        if (HP <= 0)
        {
            isDead = true;
            agent.isStopped = true;
            animator.SetTrigger("DIE");
            GetComponent<Collider>().enabled = false;
            stateMachine.enabled = false;
            GetComponent<AudioSource>().enabled = false;

            SoundManager.Instance.enemyChannel.PlayOneShot(SoundManager.Instance.enemyDead);
            if (ammoDropPrefab != null)
            {
                Instantiate(ammoDropPrefab, dropPoint.position, Quaternion.identity);
            }
            StartCoroutine(DeleteCorpse());
        }
        else
        {
            animator.SetTrigger("DAMAGE");
            SoundManager.Instance.enemyChannel.PlayOneShot(SoundManager.Instance.enemyHurt);
            
        }
    }

    private IEnumerator DeleteCorpse()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if(Vector3.Distance(transform.position,player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
