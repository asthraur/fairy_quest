using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 forward;
    Vector3 right;

    public float moveSpeed = 5f;

    Animator animator;

    private void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();



            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsRunningLeft", true);
                animator.SetBool("IsRunningRight", false);
                animator.SetBool("IsRunningFront", true);
                animator.SetBool("IsRunningBack", false);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsRunningLeft", true);
                animator.SetBool("IsRunningRight", true);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", false);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsRunningLeft", true);
                animator.SetBool("IsRunningRight", false);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", true);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsRunningLeft", false);
                animator.SetBool("IsRunningRight", true);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("IsRunningLeft", true);
                animator.SetBool("IsRunningRight", false);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsRunningLeft", false);
                animator.SetBool("IsRunningRight", true);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", false);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsRunningLeft", false);
                animator.SetBool("IsRunningRight", false);
                animator.SetBool("IsRunningFront", false);
                animator.SetBool("IsRunningBack", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsRunningLeft", false);
                animator.SetBool("IsRunningRight", false);
                animator.SetBool("IsRunningFront", true);
                animator.SetBool("IsRunningBack", false);
            }
        }
        else
        {
            animator.SetBool("IsRunningLeft", false);
            animator.SetBool("IsRunningRight", false);
            animator.SetBool("IsRunningFront", false);
            animator.SetBool("IsRunningBack", false);

        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Vector3 rightMovemet = right * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        Vector3 upMovemet = forward * moveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovemet + upMovemet);

        //transform.forward = heading;

        transform.position += rightMovemet;
        transform.position += upMovemet;


    }
    
}
