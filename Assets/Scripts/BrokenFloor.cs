using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour
{
    //Quantas vezes o jogador pode passar pelo piso quebravel
    public int life = 1;

    void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void PerdeVida()
    {
        life--;
    }
}
