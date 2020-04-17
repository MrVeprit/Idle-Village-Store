using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject shop;
    public GameObject SMBG1;
    public GameObject SMBG2;
    public void Shop()// Включение магазина
    {
        shop.SetActive(!shop.activeSelf);
        SMBG1.SetActive(true);
    }
    public void SMB1()// Включение первой вкладки
    {
        SMBG1.SetActive(true);
        SMBG2.SetActive(false);
    }
    public void SMB2()// Включение второй вкладки
    {
        SMBG1.SetActive(false);
        SMBG2.SetActive(true);
    }
}
