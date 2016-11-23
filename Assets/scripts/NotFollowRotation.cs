using UnityEngine;
using System.Collections;

public class NotFollowRotation : MonoBehaviour {
	
	void Update () {
        transform.rotation = Quaternion.identity;
	}
}
