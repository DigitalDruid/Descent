using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	// Use this for initialization setting up the scaling of the background
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		Vector3 tempScale = transform.localScale;

		float width = sr.sprite.bounds.size.x;

		float worldHight = Camera.main.orthographicSize * 2f;
		float worldWidth = worldHight / Screen.height * Screen.width;

		tempScale.x = worldWidth / width;

		transform.localScale = tempScale;
	}
	

}
