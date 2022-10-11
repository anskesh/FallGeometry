using Game.Observer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandlerUI : MonoBehaviour
{
    public PauseObserver PauseObserver { get; private set; }
    public ScoreObtainObserver ScoreObtainObserver { get; private set; }
    
    private Button _pause;
    private TextMeshProUGUI _score;

    private void Awake()
    {
        PauseObserver = new PauseObserver();
        ScoreObtainObserver = new ScoreObtainObserver(ChangeScore);
        
        _pause = GetComponentInChildren<Button>();
        _score = GetComponentInChildren<TextMeshProUGUI>();
        _pause.onClick.AddListener(PauseObserver.Notify);
    }

    private void OnDestroy()
    {
        _pause.onClick.RemoveListener(PauseObserver.Notify);
    }

    public void ChangeScore(int score)
    {
        int.TryParse(_score.text, out var oldScore);
        _score.text = (oldScore + score).ToString();
    }
}
