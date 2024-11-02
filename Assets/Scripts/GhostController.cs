using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Animator animator;
    private GhostTimer ghostTimer;
    private bool isScared = false;

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

        isScared = true;

        if (ghostTimer != null)
        {
            ghostTimer.StartTimer(10);
        }
    }

    public void SetWalkingState()
    {
        if (animator != null)
        {
            animator.SetTrigger("Walking");
        }

        isScared = false; 
    }

    public bool IsScared() 
    {
        return isScared;
    }

    public IEnumerator PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Dead"); 
        }


        yield return new WaitForSeconds(5f);
  

        animator.SetTrigger("Idle");
 
    }
}
