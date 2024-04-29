using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void BaseInteract() // t¹ funkcje wywo³uje player w momencie kiedy jest w zasiegu obiektu
    {
        Interact();
    }
    protected virtual void Interact()
    {
       //nic tu nie ma bo jest to teplate ktora bedzie nadpisywana przez klasy dziedziczace
    }
}