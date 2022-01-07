using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private Image logoImage;
    [SerializeField] private Image tapToPlayImage;
    private static StartScreen instance;
    public static StartScreen Instance => instance ?? (instance = FindObjectOfType<StartScreen>());
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Observer.startGame?.Invoke();
    }

    private void Start()
    {
        StartMenuAnimation();
    }

    public void DisableStartScreen()
    {
        this.gameObject.SetActive(false);
        this.enabled = false;
    }

    public void ActivateStartScreen()
    {
        this.gameObject.SetActive(true);
        this.enabled = true;
    }

    private void StartMenuAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(tapToPlayImage.transform.DOScale(1.2f, 1f));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}