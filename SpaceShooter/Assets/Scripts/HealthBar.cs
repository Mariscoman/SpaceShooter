using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour {

    [SerializeField] private Image _healthBarFillImage;
    [SerializeField] private Image _healthBarTrailingImage;
    [SerializeField] private float _trailDelay = 0.05f;

    private void Awake() {
        _healthBarFillImage.fillAmount = 1f;
        _healthBarTrailingImage.fillAmount = 1f;
    }

    public void DrainHealthBar(float percentage) {
        float hf = _healthBarFillImage.fillAmount, ht = _healthBarTrailingImage.fillAmount;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_healthBarFillImage.DOFillAmount(percentage, 0.15f).SetEase(Ease.InOutSine));
        sequence.AppendInterval(_trailDelay);
        sequence.Append(_healthBarTrailingImage.DOFillAmount(percentage, 0.25f).SetEase(Ease.InOutSine));
        
        sequence.Play();
    }

    public void FillHealthBar(float percentage) {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_healthBarTrailingImage.DOFillAmount(percentage, 0.15f)).SetEase(Ease.InOutSine);
        sequence.AppendInterval(_trailDelay);
        sequence.Append(_healthBarFillImage.DOFillAmount(percentage, 0.25f)).SetEase(Ease.InOutSine);

        sequence.Play();
    }
}
