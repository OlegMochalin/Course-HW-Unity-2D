using System.Collections;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private LayerMask _platformLayerMask;

    private const string IdleAnimation = "Player_idle";
    private const string RunAnimation = "Player_run";
    private const string JumpAnimation = "Player_jump";
    private const string FallAnimation = "Player_fall";
    private const string HurtAnimation = "Player_hurt";

    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriterenderer;
    private Animator _animator;

    private bool _isGrounded;
    private bool _isHurt = false;
    private float _hurtDuration = 1f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriterenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isHurt == false)
        {
            float colliderDistanceTest = 0.1f;
            RaycastHit2D raycastHit2D;

            raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, colliderDistanceTest, _platformLayerMask);
            Collider2D colliderOnBot = raycastHit2D.collider;

            raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.right, colliderDistanceTest, _platformLayerMask);
            Collider2D colliderOnRight = raycastHit2D.collider;

            raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.left, colliderDistanceTest, _platformLayerMask);
            Collider2D colliderOnLeft = raycastHit2D.collider;

            if (colliderOnBot == null)
            {
                _isGrounded = false;
            }
            else
            {
                _isGrounded = true;
            }                

            if (Input.GetKey("a"))
            {
                if(colliderOnLeft == null)
                {
                    _rigidbody2D.velocity = new Vector2(_speed * -1, _rigidbody2D.velocity.y);
                }

                _spriterenderer.flipX = true;

                if (_isGrounded)
                {
                    _animator.Play(RunAnimation);
                }
            }
            else if (Input.GetKey("d"))
            {
                if (colliderOnRight == null)
                {
                    _rigidbody2D.velocity = new Vector2(_speed, _rigidbody2D.velocity.y);
                }

                _spriterenderer.flipX = false;

                if (_isGrounded)
                {
                    _animator.Play(RunAnimation);
                }
            }
            else 
            {
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);

                if (_isGrounded)
                {
                    _animator.Play(IdleAnimation);
                }
            }

            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            }

            if (_isGrounded == false && _rigidbody2D.velocity.y > 0)
            {
                _animator.Play(JumpAnimation);
            }
            else if (_isGrounded == false && _rigidbody2D.velocity.y < 0)
            {
                _animator.Play(FallAnimation);
            }
        }
    }

    public void GetHit()
    {
        StartCoroutine(GetHurt());
    }

    private IEnumerator GetHurt()
    {
        _isHurt = true;
        float runTime = 0;              

        while (runTime < _hurtDuration)
        {
            runTime += Time.deltaTime;
            _rigidbody2D.velocity = new Vector2(0, 0);
            _animator.Play(HurtAnimation);

            yield return null;
        }

        _isHurt = false;
    }
}