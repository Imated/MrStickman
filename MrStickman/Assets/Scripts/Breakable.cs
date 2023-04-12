using DG.Tweening;
using UnityEngine;
public class Breakable : MonoBehaviour
{
    [SerializeField] protected float shakeDuration;
    [SerializeField] protected Vector3 shakeStrength;
    [SerializeField] protected int shakeVibration;
    [SerializeField] protected Sprite normalSprite;
    [SerializeField] protected Sprite brokenSprite;

    private float _health = 100;
    private SpriteRenderer _spriteRenderer;
    private bool _isBroken = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Damage(float damageLoss)
    {
        if(_isBroken)
            return;
        _health -= damageLoss;
        transform.DOShakePosition(shakeDuration, shakeStrength, shakeVibration, 180F);
        if (_health <= 0)
        {
            _spriteRenderer.sprite = brokenSprite;
            _health = 100;
            _isBroken = true;
        }
    }
}