using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Postava : MonoBehaviour
{
    public EPostavicky TypPostavy = EPostavicky.BishopB;
    public Mover MyMover;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (MyMover != null) MyMover.HraciPostava = this;
    }
    public Vector2[] GetPoziceKroku(Sachovnice deska,Vector2 pozice)
    {
        switch(deska.HraciPole[(int)pozice.x, (int)pozice.y].TypPostavy)
        {
            case EPostavicky.BishopB:
                return GetPoziceKrokuBishop(deska, pozice);
            case EPostavicky.BishopW:
                return GetPoziceKrokuBishop(deska, pozice);
            case EPostavicky.RookB:
                return GetPoziceKrokuRook(deska, pozice);
            case EPostavicky.RookW:
                return GetPoziceKrokuRook(deska, pozice);

            default: return null;
        }
    }
    public Vector2[] GetPoziceUtoku(Sachovnice deska, Vector2 pozice)
    {
        switch (deska.HraciPole[(int)pozice.x, (int)pozice.y].TypPostavy)
        {
            case EPostavicky.BishopB:
                return GetPoziceUtokuBishop(deska, pozice);
            case EPostavicky.BishopW:
                return GetPoziceUtokuBishop(deska, pozice);
            case EPostavicky.RookB:
                return GetPoziceUtokuRook(deska, pozice);
            case EPostavicky.RookW:
                return GetPoziceUtokuRook(deska, pozice);

            default: return null;
        }
    }

    public Vector2[] GetPoziceKrokuBishop(Sachovnice deska, Vector2 pozice)
    {
        float fPozX = GetComponent<Rigidbody>().position.x;
        float fPozY = GetComponent<Rigidbody>().position.y;
        int pozX = (int)fPozX;
        int pozY = (int)fPozY;
        List<Vector2> toMove = new List<Vector2>();
        bool smer1 = false, smer2 = false, smer3 = false, smer4 = false;
        for (int i = 1; i < deska.VelikostX; i++)
            for (int j = 1; j < deska.VelikostY; j++)
            {
                if (i == j)
                {
                    if (pozX + i < deska.VelikostX)
                    {
                        if (pozY + j < deska.VelikostY)
                        {
                            if (!smer1)
                                if (deska.HraciPole[pozX + i, pozY + j] == null) toMove.Add(new Vector2(fPozX + i, fPozY + j));
                                else smer1 = true;
                        }
                        if (pozY - j >= 0)
                        {
                            if (!smer2)
                                if (deska.HraciPole[pozX + i, pozY - j] == null) toMove.Add(new Vector2(fPozX + i, fPozY - j));
                                else smer2 = true;
                        }
                    }
                    if (pozX - i >= 0)
                    {
                        if (pozY + j < deska.VelikostY)
                        {
                            if (!smer3)
                                if (deska.HraciPole[pozX - i, pozY + j] == null) toMove.Add(new Vector2(fPozX - i, fPozY + j));
                                else smer3 = true;
                        }
                        if (pozY - j >= 0)
                        {
                            if (!smer4)
                                if (deska.HraciPole[pozX - i, pozY - j] == null) toMove.Add(new Vector2(fPozX - i, fPozY - j));
                                else smer4 = true;
                        }

                    }
                    if (smer1 && smer2 && smer3 && smer4) return toMove.ToArray();
                }
            }
        return toMove.ToArray();
    }
    public Vector2[] GetPoziceUtokuBishop(Sachovnice deska, Vector2 pozice)
    {
        float fPozX = GetComponent<Rigidbody>().position.x;
        float fPozY = GetComponent<Rigidbody>().position.y;
        int pozX = (int)fPozX;
        int pozY = (int)fPozY;
        List<Vector2> toMove = new List<Vector2>();
        bool smer1 = false, smer2 = false, smer3 = false, smer4 = false;
        for (int i = 1; i < deska.VelikostX; i++)
            for (int j = 1; j < deska.VelikostY; j++)
            {
                if (i == j)
                {
                    if (pozX + i < deska.VelikostX)
                    {
                        if (pozY + j < deska.VelikostY)
                        {
                            if (!smer1)
                                if (deska.HraciPole[pozX + i, pozY + j] != null)
                                {
                                    toMove.Add(new Vector2(fPozX + i, fPozY + j));
                                    smer1 = true;
                                }
                        }
                        if (pozY - j >= 0)
                        {
                            if (!smer2)
                                if (deska.HraciPole[pozX + i, pozY - j] != null)
                                {
                                    toMove.Add(new Vector2(fPozX + i, fPozY - j));
                                    smer2 = true;
                                }
                        }
                    }
                    if (pozX - i >= 0)
                    {
                        if (pozY + j < deska.VelikostY)
                        {
                            if (!smer3)
                                if (deska.HraciPole[pozX - i, pozY + j] != null)
                                {
                                    toMove.Add(new Vector2(fPozX - i, fPozY + j));
                                    smer3 = true;
                                }
                        }
                        if (pozY - j >= 0)
                        {
                            if (!smer4)
                                if (deska.HraciPole[pozX - i, pozY - j] != null)
                                {
                                    toMove.Add(new Vector2(fPozX - i, fPozY - j));
                                    smer4 = true;
                                }
                        }

                    }
                    if (smer1 && smer2 && smer3 && smer4) return toMove.ToArray();
                }
            }
        return toMove.ToArray();
    }
    public Vector2[] GetPoziceKrokuRook(Sachovnice deska, Vector2 pozice)
    {
        float fPozX = GetComponent<Rigidbody>().position.x;
        float fPozY = GetComponent<Rigidbody>().position.y;
        int pozX = (int)fPozX;
        int pozY = (int)fPozY;
        List<Vector2> toMove = new List<Vector2>();
        bool smer1 = false, smer2 = false, smer3 = false, smer4 = false;
        for (int i = 1; i < deska.VelikostX; i++)
            for (int j = 1; j < deska.VelikostY; j++)
            {
                if (pozY + j < deska.VelikostY)
                {
                    if (!smer1)
                        if (deska.HraciPole[pozX, pozY + j] == null) toMove.Add(new Vector2(fPozX, fPozY + j));
                        else smer1 = true;
                }
                if (pozY - j >= 0)
                {
                    if (!smer2)
                        if (deska.HraciPole[pozX, pozY - j] == null) toMove.Add(new Vector2(fPozX, fPozY - j));
                        else smer2 = true;
                }
                if (pozX + i < deska.VelikostX)
                {
                    if (!smer3)
                        if (deska.HraciPole[pozX + i, pozY] == null) toMove.Add(new Vector2(fPozX + i, fPozY));
                        else smer3 = true;
                }
                if (pozX - i >= 0)
                {
                    if (!smer4)
                        if (deska.HraciPole[pozX - i, pozY] == null) toMove.Add(new Vector2(fPozX - i, fPozY));
                        else smer4 = true;

                }
                if (smer1 && smer2 && smer3 && smer4) return toMove.ToArray();
            }
        return toMove.ToArray();
    }
    public Vector2[] GetPoziceUtokuRook(Sachovnice deska, Vector2 pozice)
    {
        float fPozX = GetComponent<Rigidbody>().position.x;
        float fPozY = GetComponent<Rigidbody>().position.y;
        int pozX = (int)fPozX;
        int pozY = (int)fPozY;
        List<Vector2> toMove = new List<Vector2>();
        bool smer1 = false, smer2 = false, smer3 = false, smer4 = false;
        for (int i = 1; i < deska.VelikostX; i++)
            for (int j = 1; j < deska.VelikostY; j++)
            {
                if (pozY + j < deska.VelikostY)
                {
                    if (!smer1)
                        if (deska.HraciPole[pozX, pozY + j] != null)
                        {
                            toMove.Add(new Vector2(fPozX, fPozY + j));
                            smer1 = true;
                        }
                }
                if (pozY - j >= 0)
                {
                    if (!smer2)
                        if (deska.HraciPole[pozX, pozY - j] != null)
                        {
                            toMove.Add(new Vector2(fPozX, fPozY - j));
                            smer2 = true;
                        }
                }
                if (pozX + i < deska.VelikostX)
                {
                    if (!smer3)
                        if (deska.HraciPole[pozX + i, pozY] != null)
                        {
                            toMove.Add(new Vector2(fPozX + i, fPozY));
                            smer3 = true;
                        }
                }
                if (pozX - i >= 0)
                {
                    if (!smer4)
                        if (deska.HraciPole[pozX - i, pozY] != null)
                        {
                            toMove.Add(new Vector2(fPozX - i, fPozY));
                            smer4 = true;
                        }
                }
                if (smer1 && smer2 && smer3 && smer4) return toMove.ToArray();
            }
        return toMove.ToArray();
    }
}