using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using UnityEngine.SceneManagement;

public class okane : MonoBehaviour {

    public float speed = 10;
    public GameObject root;
    public int sukoa = 0;
    public int sukoam = 20;
    public int counta = 0;
    public BigInteger coinmoti = new BigInteger("0");
    public int koinkosu = 0;

    public int syutugenlevel = 0;
    public BigInteger syutugencoin = new BigInteger("0");

    public int coinlevel = 0;
    public BigInteger coincoin = new BigInteger("0");

    public BigInteger coinpower = new BigInteger("0");

    public Text scoreText; //Text用変数
    public Text syutugenText; //Text用変数
    public Text coinText; //Text用変数
    public Text kosuText; //Text用変数

    // PlayerBulletプレハブ.
    public GameObject [] bullet;

    // Use this for initialization
    void Start()
    {
        syutugencoin = 10;
        coincoin = 10;
        coinpower = 1;
        syutugenText.text = syutugencoin.ToString();
        coinText.text = coincoin.ToString();
    }


    // Update is called once per frame
    void Update()
    {


        counta -= 1;
        if (counta >= 1) {
            Vector3 sco = new Vector3(0, 0, Random.Range(0, 60) - 30);
            transform.eulerAngles = sco;

            float a = (Random.value) * 4 + 1.0f;
            float b = (Random.value) * 4 + 1.0f;
            float c = (Random.value) * 4 + 1.0f;

            transform.localScale = new Vector3(a, b, c);
        }
        if (counta <= 0) {
            Vector3 sco2 = new Vector3(0.0f, 0.0f, 0.0f);
            transform.eulerAngles = sco2;
            transform.localScale = new Vector3(3, 3, 3);
        }
    }

    void OnMouseOver() {
        sukoa -= 1;
        if (sukoa <= 0) {
            GetComponent<AudioSource>().Play();
            sukoa = sukoam;
            buletsutat();
            if (syutugenlevel >= 5) {
                int a = 0;
                while (a <= syutugenlevel -4 && a <= 1024) {
                    buletsutat();
                    a++;
                }
            }
            scoreText.text = coinmoti.ToString();

            counta = 5;
        }
    }

    void OnMouseDown()
    {
        int a = 0;
        while (a <= syutugenlevel* syutugenlevel && a <= 1024) {
            buletsutat();
            a++;
        }
        scoreText.text = coinmoti.ToString();
        GetComponent<AudioSource>().Play();
        counta = 5;
    }

    void buletsutat()
    {
        // 弾をプレイヤーと同じ位置/角度で作成.

        coinmoti += coinpower;
        if (koinkosu >= 1024) { return; }

        float a = (Random.value) * 4 + 1.0f;
        float b = (Random.value) * 4 + 1.0f;
        float c = (Random.value) * 4 + 1.0f;

        transform.localScale = new Vector3(a, b, c);

        Vector3 sco = new Vector3(0, 0, Random.Range(0, 60) - 30);
        transform.eulerAngles = sco;
        int min1 = Mathf.Min (0,- 1 + coinlevel / 3);
        if (min1<=0) { min1 = 0; }
        int max1 = Mathf.Min(coinlevel/3, 5);

        //int max = coinlevel;
        //if (max >= 4) { max = 4; }
        int num1 = Random.Range(min1, max1);
        //if (num1 >= 4) { num1 = 4;}

        Instantiate(bullet[num1], transform.position+new Vector3(0,0,Random.Range(-1.0f,0.0f)), transform.rotation, root.transform);
        koinkosu += 1;
        //kosuText.text = koinkosu.ToString();
    }

    public bool misuthiakau()
    {
        bool modori = false;

        if (coinmoti >= 10000000) {
            modori = true;
            SceneManager.LoadScene("scene2");
        }
            return modori;
    }

    public bool syutugensiharai(){

        bool modori = false;

        if (coinmoti >= syutugencoin) {
            coinmoti -= syutugencoin;
            syutugenlevel += 1;
            modori = true;

            switch(syutugenlevel){
                case 1:
                    syutugencoin = 100;
                    sukoam = 10;
                    break;
                case 2:
                    syutugencoin = 500;
                    sukoam = 5;
                    break;
                case 3:
                    syutugencoin = 1000;
                    sukoam = 3;
                    break;
                case 4:
                    syutugencoin = 10000;
                    sukoam = 1;
                    break;
                case 5:
                    syutugencoin = 100000;
                    sukoam = 1;
                    break;
                case 6:
                    syutugencoin = 500000;
                    sukoam = 1;
                    break;
                case 7:
                    syutugencoin = 1000000;
                    sukoam = 1;
                    break;
                case 8:
                    syutugencoin = 5000000;
                    sukoam = 1;
                    break;
                case 9:
                    syutugencoin = 10000000;
                    sukoam = 1;
                    break;
                default:
                    syutugencoin = syutugencoin * 2;
                    break;

            }
            
            syutugenText.text = syutugencoin.ToString();
            scoreText.text = coinmoti.ToString();

        }

        return modori;
        }

    public bool counterherasi()
    {
        koinkosu -= 1;
        kosuText.text = koinkosu.ToString();
        return true;
    }

    public bool koinsiharai(){

        bool modori = false;

        if (coinmoti >= coincoin) {
            coinmoti -= coincoin;
            coinlevel += 1;
            modori = true;

            switch(coinlevel){
                case 1:
                    coincoin = 100;
                    coinpower = 2;
                    break;
                case 2:
                    coincoin = 500;
                    coinpower = 4;
                    break;
                case 3:
                    coincoin = 1000;
                    coinpower = 12;
                    break;
                case 4:
                    coincoin = 10000;
                    coinpower = 24;
                    break;
                case 5:
                    coincoin = 50000;
                    coinpower = 48;
                    break;
                case 6:
                    coincoin = 100000;
                    coinpower = 128;
                    break;
                case 7:
                    coincoin = 500000;
                    coinpower = 352;
                    break;
                case 8:
                    coincoin = 1000000;
                    coinpower = 642;
                    break;
                case 9:
                    coincoin = 5000000;
                    coinpower = 2468;
                    break;
                default:
                    coincoin = coincoin * 2;
                    coinpower *= 3;
                    break;
            }

            coinText.text = coincoin.ToString();
            scoreText.text = coinmoti.ToString();

        }

        return modori;
        }
}
