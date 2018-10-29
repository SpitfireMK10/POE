using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChange : MonoBehaviour {
    public GameObject Button1;
    public GameObject Button2;
    Button btnObject;

    // Use this for initialization
    void Start () {
        btnObject = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MouseEnterButton()
    {
        Button2.SetActive(false);
    }

    public void MouseExitButton()
    {
        Button2.SetActive(true);
        Button1.SetActive(false);


    }
}
