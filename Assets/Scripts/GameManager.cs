using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    Box[] boxes;
    Collectable[] collectables;
    bool todosColoridos;
    bool todosColetados;
    float yKillZone = -2;
    public Transform playerReference;
    public int caixas = 0;
    public TMP_Text textCaixas;

    void Start()
    {
        //Busca todas caixas e coletaveis da cena
        boxes = FindObjectsOfType<Box>();
        collectables = FindObjectsOfType<Collectable>();
    }


    void Update()
    {
        //UI de caixas coletadas
        textCaixas.text = caixas + "/" + boxes.Length;

        //Verifica se cumpriu condições de vitória
        if (todosColoridos && todosColetados)
        {
            //Espera antes de encerrar jogo
            Invoke(nameof(CarregaEndGame), 1f);
        }
        else
        {
            //Executa metodos de verificação apenas se ainda não satifez a condição
            if (!todosColoridos) { ColoredBoxes(); }
            if (!todosColetados) { CollectedItens(); }
        }

        //Reseta se jogador cair
        if(playerReference.position.y < yKillZone)
        {
            SceneManager.LoadScene("Game");
        }
    }

    void ColoredBoxes()
    {
        todosColoridos = true;
        //Verifica se caixas já foram pintadas
        foreach (Box box in boxes)
        {
            if (!box.isColored)
            {
                todosColoridos = false;
                break;
            }
        }
    }

    void CollectedItens()
    {
        todosColetados = true;
        //Verifica se itens foram coletados
        foreach(Collectable collectable in collectables)
        {
            if (!collectable.isCatched)
            {
                todosColetados = false;
                break;
            }
        }
    }

    private void CarregaEndGame()
    {
        //Carrega cena de fim de jogo
        SceneManager.LoadScene("EndGame");
    }
}
