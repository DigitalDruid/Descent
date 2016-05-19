using UnityEngine;
using System.Collections;

public class BGCollector : MonoBehaviour {

	//deactivating the backgrounds
	void OnTriggerEnter2D(Collider2D target){
		if( target.tag == "Background"){
			target.gameObject.SetActive(false);
		}
	}
}
