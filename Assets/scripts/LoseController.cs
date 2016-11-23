using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoseController : MonoBehaviour {

    [SerializeField]
    private Text loseText;

	// Use this for initialization
	void Start () {
        Audio.StopBGM();
        Audio.PlaySND1(Audio.SND_LOSE);
        loseText.text += Constants.GetCurrentWave();
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
}
