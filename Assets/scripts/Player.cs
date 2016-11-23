using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed = 40f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [SerializeField]
    private float attackDelay = 1f;

    private Vector2 _movement;
    private Quaternion _facingAngle;

    private Rigidbody2D _rb;

    private float _attackTime;
    private bool _startAttackTimer = false;

    private float _secondCounter = 0f;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();

        /*
         ParticleSystem particle = Instantiate(_particleSystem, transform.position, Quaternion.identity, transform) as ParticleSystem;
         Debug.Log("Particle: " + particle);
         particle.GetComponent<Renderer>().sortingLayerName = "Particles";
         particle.Play(); 
         */
    }

    // Update is called once per frame
    void Update () {
        if (_startAttackTimer) {
            _attackTime += Time.deltaTime;

            if (_attackTime > attackDelay) {
                _startAttackTimer = false;
                _attackTime = 0f;

                Debug.Log("Attack refreshed");
            }
        }

        if (Input.GetKeyDown("space")) {
            Attack();
        }
    }

    void FixedUpdate() {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        if (_movement.x != 0 || _movement.y != 0)
        {
            _facingAngle = Quaternion.AngleAxis(Mathf.Atan2(-_movement.x, _movement.y) * Mathf.Rad2Deg, Vector3.forward);
            transform.rotation = _facingAngle;

            _rb.AddForce(_movement * speed);

            animator.SetBool("Walking", true);
        } else {
            animator.SetBool("Walking", false);
        }
    }

    public void Attack() {
        if (!_startAttackTimer) {
            attackAnimator.SetTrigger("Attack");
            animator.SetTrigger("Attack");
            _startAttackTimer = true;
            Audio.PlaySND1(Audio.SND_FIRE_BREATH, 0.2f);
        }
    }

    public void OnMouseDown() {
        Attack();
    }
}
