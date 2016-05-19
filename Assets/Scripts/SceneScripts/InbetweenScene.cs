using UnityEngine;
using System.Collections;

public class InbetweenScene : MonoBehaviour {

    [SerializeField]
    private GameObject continueButton;

    public void OnClick(){
        Time.timeScale = 1f;
        continueButton.SetActive(false);
        GameManager.instance.gotoNextScene();
    }
}
