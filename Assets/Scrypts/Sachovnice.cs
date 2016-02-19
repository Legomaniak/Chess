using UnityEngine;
using System.Collections;

public class Sachovnice : MonoBehaviour {
    public int VelikostX = 8;
    public int VelikostY = 8;
    public GameObject Cerna;
    public GameObject Bila;
    public GameObject RookW;
    public GameObject PawnW;
    public GameObject BishopW;
    public GameObject RookB;
    public GameObject PawnB;
    public GameObject BishopB;
    public Mover MyMover;
    public Postava[,] HraciPole
    {
        get { return _HraciPole; }
        private set { _HraciPole = value; }
    }
    Postava[,] _HraciPole;
    // Use this for initialization
    void Start () {
        HraciPole = new Postava[VelikostX, VelikostY];

        for (int i = 0; i < VelikostX; i++)
            for (int j = 0; j < VelikostY; j++)
                if ((i  + j) % 2 == 0)
                    Instantiate(Cerna, new Vector3(i, j, 1), new Quaternion());
                else
                    Instantiate(Bila, new Vector3(i, j, 1), new Quaternion());
        Rozdej();
    }
	void Rozdej()
    {
        Quaternion natoceni = new Quaternion();
        natoceni.eulerAngles = new Vector3(0, 270, 0);
        GameObject go = Instantiate(RookB, new Vector3(0, 0, 0), natoceni) as GameObject;
        Postava p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[0, 0] = p;
        go = Instantiate(PawnB, new Vector3(1, 0, 0), natoceni) as GameObject;
        p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[1, 0] = p;
        go = Instantiate(BishopB, new Vector3(2, 0, 0), natoceni) as GameObject;
        p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[3, 0] = p;


        go = Instantiate(RookW, new Vector3(7, 7, 0), natoceni) as GameObject;
        p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[7, 7] = p;
        go = Instantiate(PawnW, new Vector3(6, 7, 0), natoceni) as GameObject;
        p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[6, 7] = p;
        go = Instantiate(BishopW, new Vector3(5, 7, 0), natoceni) as GameObject;
        p = go.GetComponent<Postava>();
        p.MyMover = MyMover;
        HraciPole[5, 7] = p;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
