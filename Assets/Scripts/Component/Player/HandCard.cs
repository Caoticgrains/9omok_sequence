using System;
using Component.Board;
using Data;
using Manager;
using UnityEngine;
using UnityEngine.UI;

public class HandCard : MonoBehaviour
{
    private Image _image;
    public Content content;
    public Owner owner;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        GameManager.Instance.SelectHandCard(this);
    }
}
