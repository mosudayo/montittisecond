﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koinsyutugenup : MonoBehaviour
{

    private okane money;

    // Use this for initialization
    void Start()
    {
        GameObject aiueo;
        aiueo = GameObject.Find("tintin");
        money = aiueo.GetComponent<okane>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (money.syutugensiharai()) { GetComponent<AudioSource>().Play(); }
    }
}