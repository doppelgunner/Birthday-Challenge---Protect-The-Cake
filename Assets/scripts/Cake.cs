using UnityEngine;
using System.Collections;

public class Cake : MonoBehaviour {

    public const float MAX_HEALTH = 300f;

    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private Animator animator;

    private bool _alive = true;
    private float _health = MAX_HEALTH;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(float f) {
        if (!_alive) return;

        if (_health > 0) {
            _health -= f;

            if (_health < 0) _health = 0;
            else if (_health > MAX_HEALTH) _health = MAX_HEALTH;

            healthBar.transform.localScale = new Vector3(_health / MAX_HEALTH ,1,1);
            animator.SetTrigger("Hit");
        } else {
            _alive = false;
            animator.SetBool("Alive", _alive);

            StartCoroutine(OnDeath(2f));
        }
    }

    public bool IsAlive() {
        return _alive;
    }

    private IEnumerator OnDeath(float delay) {
        //go to another scene after a delay
        yield return new WaitForSeconds(delay);
        Constants.GoToScene("Lose");
    }
    


}
