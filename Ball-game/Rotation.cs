﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	void Update () {
		transform.Rotate(new Vector3 (12,30,45)*Time.deltaTime);
	}
}
