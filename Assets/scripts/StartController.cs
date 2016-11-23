using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(500,500,false);
        Audio.PlayBGM(Audio.BGM_START, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
