using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //Variavel para saber se item foi coletado
    public bool isCatched;
    public Image notCatched, catched;

    void Start()
    {
        //Inicializa indicador UI do coletavel
        catched.enabled = false;
        notCatched.enabled = true;
    }
}
