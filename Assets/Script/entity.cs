using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{
    [Header("collision info")]
    [SerializeField] protected Transform GroundCheck;
    [SerializeField] protected float GroundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;

    [SerializeField] private LayerMask whatIsGround;
    // Start is called before the first frame update

    #region component
    public Animator anim;
    public Rigidbody2D rb;
    #endregion componet

    public int facingDir { get; private set; } = 1;
    protected bool facingright = true;
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    #region Velocity
    public void SetVelocity(float velocity_x, float velocity_y)
    {
        rb.velocity = new Vector2(velocity_x, velocity_y);
        FlipControl(velocity_x);
    }
    public void zeroVector() => rb.velocity = Vector2.zero;
    #endregion
    #region collision
    public virtual bool IsGroundDetected() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
    }
    #endregion
    #region flipControl
    public virtual void Flip()
    {
        facingDir *= -1;
        facingright = !facingright;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipControl(float _x)
    {
        if (_x > 0 && !facingright)
        {
            Flip();
        }
        else if (_x < 0 && facingright)
        {
            Flip();
        }
    }
    #endregion
}