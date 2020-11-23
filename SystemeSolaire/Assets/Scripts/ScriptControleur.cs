using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptControleur : MonoBehaviour
{

    /// <summary>
    /// Mouvement de la terre
    /// </summary>
    public float alphaTerre = 0f;

    /// <summary>
    /// Mouvement de la lune
    /// </summary>
    public float alphaLune = 0f;

    /// <summary>
    /// Mouvemenet de Vénus
    /// </summary>
    public float alphaVenus = 0f;

    /// <summary>
    /// Mouvement de Mars
    /// </summary>
    public float alphaMars = 0f;

    /// <summary>
    /// Vitesse de la terre
    /// </summary>
    public float vitesseTerre = 0.01f;

    /// <summary>
    /// Vitesse de la lune
    /// </summary>
    public float vitesseLune = 0.02f;

    /// <summary>
    /// Vitesse de Vénus
    /// </summary>
    public float vitesseVenus = 0.005f;

    /// <summary>
    /// Vitesse de Mars
    /// </summary>
    public float vitesseMars = 0.009f;


    public float decentralisation = 10f;

    public GameObject soleil;
    public GameObject terre;
    public GameObject lune;
    public GameObject mars;
    public GameObject venus;

    public Vector3 centreSoleil;
    public Vector3 centreTerre;

    public GameObject vaisseau;
    public Text positionJoueur;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        centreSoleil = new Vector3(soleil.transform.position.x + decentralisation, 0, soleil.transform.position.z);
        centreTerre = terre.transform.position;

        terre.transform.Rotate(0.2f, 0.2f, 0, Space.World);
        venus.transform.Rotate(0.2f, 0, 0.2f, Space.World);
        mars.transform.Rotate(0.2f, 0, 0.2f, Space.World);


        terre.transform.position = new Vector3(centreSoleil.x + 45 * Mathf.Cos(alphaTerre), centreSoleil.y + 40 * Mathf.Sin(alphaTerre), 0);
        lune.transform.position = new Vector3(centreTerre.x + 10 * Mathf.Cos(alphaLune), centreTerre.y + 10 * Mathf.Sin(alphaLune), 0.0f);


        mars.transform.position = new Vector3(centreSoleil.x + 60 * Mathf.Cos(alphaMars), 0, centreSoleil.z + 55 * Mathf.Sin(alphaMars));
        venus.transform.position = new Vector3(centreSoleil.x + 30 * Mathf.Cos(alphaVenus), 0, centreSoleil.z + 35 * Mathf.Sin(alphaVenus));


        alphaTerre += vitesseTerre;
        alphaMars += vitesseMars;
        alphaVenus += vitesseVenus;
        alphaLune += vitesseLune;


        positionJoueur.text = "Position vaisseau : X(" + Math.Round(vaisseau.transform.position.x, 2) + ") Y( " + Math.Round(vaisseau.transform.position.y, 2) + ") Z(" + Math.Round(vaisseau.transform.position.z, 2) + ")";
    }
}
