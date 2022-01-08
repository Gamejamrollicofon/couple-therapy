using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticle : MonoBehaviour
{
    #region Singleton
    private static UIParticle instance;
    public static UIParticle Instance => instance ?? (instance = FindObjectOfType<UIParticle>());
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

    #endregion
    [SerializeField] ParticleSystem brokenHeart;
    [SerializeField] ParticleSystem heart;

    [SerializeField] private bool isParticlePlay;


    public void PlayParticle(CollectableType type)
    {
        if (type == CollectableType.Positive)
        {
            heart.Play();
        }
        else
        {
            brokenHeart.Play();
        }
    }
}