using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour
{
    Rigidbody rb;
    GameManager manager;
    public float jumpStr = 7;
    public float speed = 2;
    public bool isGround;

    void Start()
    {
        //Recebe referencia rigidbody
        rb = GetComponent<Rigidbody>();

        //Recebe gameManager
        manager = GameObject.FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        //Pulo - se apertar espaço e estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpStr, ForceMode.Impulse);
            isGround = false;
        }

    }

    void FixedUpdate()
    {
        //Movimentação
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(hMove, 0, vMove);

        rb.AddForce(moveDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //otherObject: referencia para objeto que colidiu
        GameObject otherObject = collision.gameObject;

        //Verifica se personagem está no chão
        if(otherObject.tag == "Floor")
        {
            isGround = true;
        }

        //Colisão com caixa para pintar
        if (otherObject.GetComponent<Box>() != null)
        {
            //Verifica se já foi colorida
            if (!otherObject.GetComponent<Box>().isColored)
            {
                //Pinta de vermelho
                MeshRenderer mr;
                mr = collision.gameObject.GetComponent<MeshRenderer>();
                float r, g, b;
                r = 0.8f; //Random.Range(0.0f, 1.0f);
                g = 0; //Random.Range(0.0f, 1.0f);
                b = 0; //Random.Range(0.0f, 1.0f);
                mr.material.color = new Color(r, g, b);

                //Registra que a caixa já foi pintada e contador UI
                otherObject.GetComponent<Box>().isColored = true;
                manager.GetComponent<GameManager>().caixas++;

            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //otherObject: referencia para objeto que colidiu
        GameObject otherObject = collision.gameObject;

        //Chão quebravel
        if (otherObject.GetComponent<BrokenFloor>() != null)
        {
            BrokenFloor brokenFloor = otherObject.GetComponent<BrokenFloor>();
            brokenFloor.PerdeVida();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Colisão com coletavel, atualiza 
        if (other.tag == "Collectable")
        {
            other.GetComponent<Collectable>().isCatched = true;
            other.GetComponent<Collectable>().notCatched.enabled = false;
            other.GetComponent<Collectable>().catched.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
