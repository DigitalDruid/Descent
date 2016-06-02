using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    [SerializeField]
	private float speed = 1f, acceleration = 0.2f, maxSpeed = 3.2f;

    [SerializeField]
	private float easySpeed = 3.2f, mediumSpeed = 3.7f, hardSpeed = 4.2f;

	[HideInInspector]
	public bool moveCamera;

	// Use this for initialization
	void Start () {
        switch (GamePreferences.DifficultyState) {
            case GamePreferences.EasyDifficulty: maxSpeed = easySpeed; break;
            case GamePreferences.HardDifficulty: maxSpeed = hardSpeed; break;
            case GamePreferences.MediumDifficulty: default: maxSpeed = mediumSpeed; break;
        }
        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveCamera){
			MoveCamera();
		}
	}

	void MoveCamera(){
		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newY = temp.y - (speed * Time.deltaTime);

		temp.y = Mathf.Clamp (temp.y , oldY, newY);

		transform.position = temp;

		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed){
			speed = maxSpeed;
		}
	}
}
