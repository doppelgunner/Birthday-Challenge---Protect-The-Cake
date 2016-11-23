using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private Vector2 attackDamageRange = new Vector2(4,6);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //Instantiate(cakeDamageEffect, other.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().Damage(Random.Range(attackDamageRange.x, attackDamageRange.y));
        } else if (other.tag == "Cake") {
            other.gameObject.GetComponent<Cake>().Damage(- Random.Range(attackDamageRange.x, attackDamageRange.y));
        }

    }
}
