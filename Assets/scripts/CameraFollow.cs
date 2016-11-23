using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    GameObject follow;
    [SerializeField]
    private GameObject leftClip;
    [SerializeField]
    private GameObject rightClip;
    [SerializeField]
    private GameObject topClip;
    [SerializeField]
    private GameObject botClip;

    private float newX;
    private float newY;
    private float halfSize;

    // Use this for initialization
    void Awake() {
        
    }

	void Start () {
        halfSize = Camera.main.orthographicSize / 2f;
    }
	
	// Update is called once per frame
	void Update () {
        newX = follow.transform.position.x;
        newY = follow.transform.position.y;

        newX = Mathf.Clamp(newX, leftClip.transform.position.x, rightClip.transform.position.x);
        newY = Mathf.Clamp(newY, botClip.transform.position.y, topClip.transform.position.y);

        transform.position = new Vector3(newX, newY, transform.position.z);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
