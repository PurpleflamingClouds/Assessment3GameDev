using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Get the Animator component attached to the ghost
        animator = GetComponent<Animator>();
    }

    public void SetScaredState()
    {
        if (animator != null)
        {
            animator.SetTrigger("Scared"); // Set the trigger for the scared state
        }
    }

    public void SetWalkingState()
    {
        if (animator != null)
        {
            animator.SetTrigger("Walking"); // Set the trigger for the walking state
        }
    }
}
