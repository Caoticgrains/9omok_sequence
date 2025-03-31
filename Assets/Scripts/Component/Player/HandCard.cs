using System;
using UnityEngine;
using UnityEngine.UI;

public class HandCard : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Debug.Log(gameObject.name + " clicked");
    }
}
