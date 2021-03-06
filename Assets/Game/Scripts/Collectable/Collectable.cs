using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    [SerializeField] public CollectableType type;
    [SerializeField] private float value;
    [SerializeField] private float rotationY = 360f;

    [SerializeField] private float moveY;

    private void Start()
    {
        HandleAnimation();
    }
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            var tmpValue = type == CollectableType.Positive ? value : -value;
            Observer.updateLove?.Invoke(tmpValue);
            Observer.PlayParticle?.Invoke(ParticleType.Collectable, (int)type);
        }
    }

    private void HandleAnimation()
    {
        transform.DOLocalMoveY(moveY, 1f, false).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalRotate(Vector3.up * rotationY, 3f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
    }
}

