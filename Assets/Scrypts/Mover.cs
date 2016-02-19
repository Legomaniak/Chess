using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour
{
    public GameObject CubePozice;
    public GameObject CubeUtok;
    public Sachovnice Deska;
    public Postava HraciPostava
    {
        get { return _HraciPostava; }
        set
        {
            ClearObjekty();
            _HraciPostava = value;
            Vector2[] ToMove = _HraciPostava.GetPoziceKroku(Deska,new Vector2());
            
            foreach(Vector2 v in ToMove)
            {
                GameObject go = Instantiate(CubePozice, new Vector3(v.x, v.y, 0), new Quaternion()) as GameObject;
                go.AddComponent<Pozicovac>();
                go.GetComponent<Pozicovac>().MyMover = this;
                Objekty.Add(go);
            }
            Vector2[] ToUtok = _HraciPostava.GetPoziceUtoku(Deska, new Vector2());
            foreach (Vector2 v in ToUtok)
            {
                GameObject go = Instantiate(CubeUtok, new Vector3(v.x, v.y, 0), new Quaternion()) as GameObject;
                go.AddComponent<Pozicovac>();
                go.GetComponent<Pozicovac>().MyMover = this;
                Objekty.Add(go);
            }
        }
    }
    
    public void Posun(Vector2 pozice)
    {
        if (HraciPostava == null) return;
        ClearObjekty();
        float fPozX = HraciPostava.GetComponent<Rigidbody>().position.x;
        float fPozY = HraciPostava.GetComponent<Rigidbody>().position.y;
        float fPozZ = HraciPostava.GetComponent<Rigidbody>().position.z;
        int pozX = (int)fPozX;
        int pozY = (int)fPozY;
        if (Deska.HraciPole[(int)pozice.x, (int)pozice.y] != null)
        {
            Destroy(Deska.HraciPole[(int)pozice.x, (int)pozice.y]);
            Deska.HraciPole[(int)pozice.x, (int)pozice.y] = null;
        }
        HraciPostava.GetComponent<Rigidbody>().MovePosition(new Vector3(pozice.x, pozice.y, fPozZ));
        Deska.HraciPole[pozX, pozY] = null;
        Deska.HraciPole[(int)pozice.x, (int)pozice.y] = HraciPostava;
    }

    List<GameObject> Objekty = new List<GameObject>();
    Postava _HraciPostava;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ClearObjekty()
    {
        foreach (GameObject g in Objekty)
        {
            Destroy(g);
        }
        Objekty.Clear();
    }
}
