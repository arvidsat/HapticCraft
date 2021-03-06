﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    FalconSpringedBody fsb;
    Renderer renderer;

    bool active = false;

    public Material highlight;
    public Material neutral;

    public WhackAMole whackAMole;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        fsb = GetComponent<FalconSpringedBody>();
        fsb.springPos = transform.position;
	}
	
    public void setActive() {
        renderer.material = highlight;
        active = true;
    }

    public bool GetActive() {
        return active;
    }

    public void Deactivate() {
        renderer.material = neutral;
        active = false;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            if(active) {
                whackAMole.ButtonPushed();
            }
            renderer.material = neutral;
            active = false;
        }
    }
}
