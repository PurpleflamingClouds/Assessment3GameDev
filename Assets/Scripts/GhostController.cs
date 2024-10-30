using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator; 
    private GhostTimer ghostTimer; 

    private void Start()
    {

        animator = GetComponent<Animator>();
        ghostTimer = Object.FindFirstObjectByType<GhostTimer>(); 
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
