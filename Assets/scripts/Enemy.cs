using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public const float MAX_HEALTH = 10f;

    [SerializeField]
    private float health = MAX_HEALTH;
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float minDistanceForAttacking = 1.35f;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private float destroyTime;


    private Cake _cakeScript;

    private float _attackTime;
    private bool _startAttackTimer = false;
    private GameObject _cake;

    private bool _alive = true;

    private List<GameObject> enemyList;
   
    private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();

        _cake = GameObject.FindGameObjectsWithTag("Cake")[0];
        _cakeScript = _cake.GetComponent<Cake>();
	}
	
	// Update is called once per frame
	void Update () {

        if (_startAttackTimer)
        {
            _attackTime += Time.deltaTime;

            if (_attackTime > attackDelay)
            {
                _startAttackTimer = false;
                _attackTime = 0f;
            }
        }

    }

    void FixedUpdate() {
        float z = Mathf.Atan2(
            (_cake.transform.position.y - transform.position.y),
            (_cake.transform.position.x - transform.position.x)
            ) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);

        float dist = Vector2.Distance(_cake.transform.position, transform.position);


        //if alive then check distance
        if (_cakeScript.IsAlive()) {
            if (dist > minDistanceForAttacking)
            {
                _rb.AddForce(transform.up * speed);
                animator.SetBool("Walking", true);
            }
            else
            {
                Attack();
            }
        } else {
            animator.SetBool("Walking", false);
        }
    }

    public void Attack()
    {
        if (!_startAttackTimer)
        {
            attackAnimator.SetTrigger("Attack");
            animator.SetTrigger("Attack");

            _startAttackTimer = true;

            Audio.PlaySND2(Audio.SND_COLD_BREATH);
        }
    }

    public void Damage(float f)
    {
        if (!_alive) return;

        if (health > 0)
        {
            health -= f;

            if (health < 0) health = 0;
            healthBar.transform.localScale = new Vector3(health / MAX_HEALTH, 1, 1);
        }
        else
        {
            _alive = false;
            animator.SetBool("Alive", _alive);
            StartCoroutine(OnDeath());
        }
    }

    private IEnumerator OnDeath() {
        yield return new WaitForSeconds(destroyTime);
        RemoveFromList();
        Destroy(gameObject);
    }

    public void SetEnemyList(List<GameObject> enemyList) {
        this.enemyList = enemyList;
    }

    private void RemoveFromList() {
        if (enemyList != null) {
            enemyList.Remove(this.gameObject);
        }
    }
}
