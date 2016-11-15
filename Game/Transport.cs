using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transport : MonoBehaviour {
    public Object sceneToLoad;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
