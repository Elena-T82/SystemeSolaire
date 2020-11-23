using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaisseau : MonoBehaviour
{
    // Start is called before the first frame update

    public float vitesse = 10f;
    public Vector3 moveDirection = Vector3.zero;

    public Camera CameraAvant;
    public Camera CameraArriere;
    public Camera CameraExterieur;
    public Camera Camera3emePersonne;

    public GameObject lumiere1;
    public GameObject lumiere2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //-------------Les déplacements--------------------


        //Avancer, reculer, rotation droite et gauche

        if (Input.GetKey(KeyCode.Z)) //GetKey : tant que la key est appuyée.
        {
            moveDirection = new Vector3(0, 0, -0.7f) * vitesse * Time.deltaTime;
            transform.position += transform.TransformDirection(moveDirection); //permet d'avancer en prenant en compte la rotation

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Z)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        if (Input.GetKey(KeyCode.Q)) //GetKey : tant que la key est appuyée.
        {
            transform.Rotate (- Vector3.up * vitesse * 10 * Time.deltaTime); //rotation gauche

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        if (Input.GetKey(KeyCode.S)) //GetKey : tant que la key est appuyée.
        {
            moveDirection = new Vector3(0, 0, 0.7f) * vitesse * Time.deltaTime;
            transform.position += transform.TransformDirection(moveDirection);

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        if (Input.GetKey(KeyCode.D)) //GetKey : tant que la key est appuyée.
        {
            transform.Rotate (Vector3.up * (Input.GetAxis("Horizontal") * vitesse * 10 * Time.deltaTime)); //rotation droite

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.D)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        //Monter ou descendre


        if (Input.GetKey(KeyCode.Space)) //Permet de monter
        {
            transform.position += new Vector3(0, 0.7f, 0) * vitesse * Time.deltaTime;

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Space)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        if (Input.GetKey(KeyCode.LeftShift)) //Permet de descendre
        {
            transform.position += new Vector3(0, -0.7f, 0) * vitesse * Time.deltaTime;

            lumiere1.SetActive(true);
            lumiere2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //si la key est relaché
        {
            lumiere1.SetActive(false);
            lumiere2.SetActive(false);
        }


        //---------------Les caméras------------------------



        if (Input.GetKeyDown(KeyCode.E)) //Si la key est appuyé une fois
        {
            if (CameraAvant.depth == 1) //Permet de basculer sur la caméra arriere
            {
                CameraArriere.depth = 1;
                CameraAvant.depth = 0;
                CameraExterieur.depth = 0;
            }
            else                        //Permet de basculer sur la caméra avant
            {
                CameraAvant.depth = 1;
                CameraArriere.depth = 0;
                CameraExterieur.depth = 0;

            }
        }

        if (Input.GetKeyDown(KeyCode.R)) //Permet de basculer sur la caméra de la 3eme personne
        {
            Camera3emePersonne.depth = 1;
            CameraAvant.depth = 0;
            CameraArriere.depth = 0;
            CameraExterieur.depth = 0;
        }

        if (Input.GetKeyDown(KeyCode.A)) //Si la key est appuyé une fois
        {
            if (CameraExterieur.depth == 0) //Permet de basculer sur la caméra exterieur
            {
                CameraExterieur.depth = 1;
                CameraAvant.depth = 0;
                CameraArriere.depth = 0;
            }
        }
    }
}
