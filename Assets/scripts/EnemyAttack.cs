using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

   // [SerializeField]
   // private GameObject cakeDamageEffect;
    [SerializeField]
    private Vector2 attackDamageRange = new Vector2(2,4);

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Cake") {
            //Instantiate(cakeDamageEffect, other.transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Cake>().Damage(Random.Range(attackDamageRange.x, attackDamageRange.y));
        }
        
    }
}
