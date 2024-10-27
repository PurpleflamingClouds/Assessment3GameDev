using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Vector3 targetPosition;
    private bool isMoving;
    private int lastInput;
    private Animator animator;
    private AudioSource audioSource;
    public ParticleSystem characterTrail;

    private const int IDLE = 0;
    private const int UP = 1;
    private const int DOWN = 2;
    private const int LEFT = 3;
    private const int RIGHT = 4;

    void Start()
    {
        targetPosition = transform.position;
        lastInput = IDLE;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (characterTrail != null)
        {
            characterTrail.Stop();
        }
    }

    void Update()
    {
        GatherInput();

        if (isMoving)
        {
            MoveTowardsTarget();
            PlayMovementAudio();
            PlayMovementParticles();
        }
        else
        {
            StopMovementAudio();
            StopMovementParticles();
        }

        UpdateAnimator();
    }

    public void MoveTo(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isMoving = true;
    }

    private void MoveTowardsTarget()
    {
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }

    private void GatherInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = UP;
            MoveTo(transform.position + Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = LEFT;
            MoveTo(transform.position + Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = DOWN;
            MoveTo(transform.position + Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = RIGHT;
            MoveTo(transform.position + Vector3.right);
        }

        if (isMoving && !Input.anyKeyDown)
        {
            switch (lastInput)
            {
                case UP:
                    MoveTo(transform.position + Vector3.up);
                    break;
                case DOWN:
                    MoveTo(transform.position + Vector3.down);
                    break;
                case LEFT:
                    MoveTo(transform.position + Vector3.left);
                    break;
                case RIGHT:
                    MoveTo(transform.position + Vector3.right);
                    break;
            }
        }
    }

    private void UpdateAnimator()
    {
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            animator.SetInteger("Direction", lastInput);
        }
        else
        {
            animator.SetInteger("Direction", IDLE);
        }
    }

    private void PlayMovementAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopMovementAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void PlayMovementParticles()
    {
        if (characterTrail != null && !characterTrail.isPlaying)
        {
            characterTrail.Play();
        }
    }

    private void StopMovementParticles()
    {
        if (characterTrail != null && characterTrail.isPlaying)
        {
            characterTrail.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Wall"))
        {
            // wall things
        }


        if (collider.CompareTag("Teleporter"))
        {

            Teleport(new Vector3(11f, -6.8f, 0f));
        }



        if (collider.CompareTag("TeleporterTwo"))
        {

            Teleport(new Vector3(-4.63f, -6.8f, 0f));
        }



    }

    private void Teleport(Vector3 newPosition)
    {
        transform.position = newPosition; 
    }
}
