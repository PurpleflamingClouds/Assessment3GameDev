using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private GhostTimer ghostTimer; // Reference to the GhostTimer

    private void Start()
    {
        // Get the Animator component attached to the ghost
        animator = GetComponent<Animator>();
        ghostTimer = Object.FindFirstObjectByType<GhostTimer>(); // Find the GhostTimer instance
    }

    public void SetScaredState()
    {
        if (animator != null)
        {
            animator.SetTrigger("Scared");
        }

        if (ghostTimer != null)
        {
            ghostTimer.StartTimer();
        }
    }

    public void SetWalkingState()
    {
        if (animator != null)
        {
            animator.SetTrigger("Walking");
        }
    }
}
