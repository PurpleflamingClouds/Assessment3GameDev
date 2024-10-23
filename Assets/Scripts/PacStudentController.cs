using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which PacStudent moves
    private Vector3 targetPosition; // Target position to move towards
    private bool isMoving; // Flag to check if PacStudent is currently moving
    private int lastInput; // Store the last input direction as an integer
    private Animator animator; // Reference to the Animator component
    private AudioSource audioSource; // Reference to the AudioSource component
    public ParticleSystem dirtTrail; // Reference to the Particle System

    // Direction constants
    private const int IDLE = 0;
    private const int UP = 1;
    private const int DOWN = 2;
    private const int LEFT = 3;
    private const int RIGHT = 4;

    void Start()
    {
        targetPosition = transform.position; // Set the initial position
        lastInput = IDLE; // Initialize last input as idle
        animator = GetComponent<Animator>(); // Get the Animator component
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        if (dirtTrail != null)
        {
            dirtTrail.Stop(); // Make sure the particle system is stopped at the start
        }
    }

    void Update()
    {
        GatherInput(); // Check for player input

        // Move towards the target position using Lerp
        if (isMoving)
        {
            MoveTowardsTarget();
            PlayMovementAudio(); // Play audio if moving
            PlayMovementParticles(); // Play particles if moving
        }
        else
        {
            StopMovementAudio(); // Stop audio if not moving
            StopMovementParticles(); // Stop particles if not moving
        }

        UpdateAnimator(); // Update the animator based on movement
    }

    // Public method to set a new target position
    public void MoveTo(Vector3 newPosition)
    {
        targetPosition = newPosition;
        isMoving = true; // Start moving towards the new position
    }

    private void MoveTowardsTarget()
    {
        // Calculate step size based on speed and delta time
        float step = moveSpeed * Time.deltaTime;

        // Move PacStudent towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if PacStudent has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // Snap to the target position and stop moving
            transform.position = targetPosition;
            isMoving = false; // Stop moving
        }
    }

    private void GatherInput()
    {
        // Gather input for movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = UP; // Up
            MoveTo(transform.position + Vector3.up); // Move up
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = LEFT; // Left
            MoveTo(transform.position + Vector3.left); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = DOWN; // Down
            MoveTo(transform.position + Vector3.down); // Move down
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = RIGHT; // Right
            MoveTo(transform.position + Vector3.right); // Move right
        }

        // Continue moving in the last input direction if the key is held down
        if (isMoving && !Input.anyKeyDown)
        {
            switch (lastInput)
            {
                case UP:
                    MoveTo(transform.position + Vector3.up); // Keep moving up
                    break;
                case DOWN:
                    MoveTo(transform.position + Vector3.down); // Keep moving down
                    break;
                case LEFT:
                    MoveTo(transform.position + Vector3.left); // Keep moving left
                    break;
                case RIGHT:
                    MoveTo(transform.position + Vector3.right); // Keep moving right
                    break;
            }
        }
    }

    private void UpdateAnimator()
    {
        // Set the IsMoving parameter based on movement state
        animator.SetBool("IsMoving", isMoving);

        // Update the Direction parameter based on last input
        if (isMoving)
        {
            animator.SetInteger("Direction", lastInput); // Set direction based on integer value
        }
        else
        {
            animator.SetInteger("Direction", IDLE); // Idle or reset to default
        }
    }

    private void PlayMovementAudio()
    {
        if (!audioSource.isPlaying) // Check if audio is not already playing
        {
            audioSource.Play(); // Play the audio
        }
    }

    private void StopMovementAudio()
    {
        if (audioSource.isPlaying) // Check if audio is playing
        {
            audioSource.Stop(); // Stop the audio
        }
    }

    private void PlayMovementParticles()
    {
        if (dirtTrail != null && !dirtTrail.isPlaying) // Check if the particle system is not playing
        {
            dirtTrail.Play(); // Play the particle system
        }
    }

    private void StopMovementParticles()
    {
        if (dirtTrail != null && dirtTrail.isPlaying) // Check if the particle system is playing
        {
            dirtTrail.Stop(); // Stop the particle system
        }
    }
}
