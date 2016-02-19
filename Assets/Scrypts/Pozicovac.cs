using UnityEngine;
using System.Collections;
using System;

public class Pozicovac : MonoBehaviour {

    public Mover MyMover;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        if (MyMover == null) return;

        float fPozX = transform.position.x;
        float fPozY = transform.position.y;

        MyMover.Posun(new Vector2((int)fPozX, (int)fPozY));
    }
}
