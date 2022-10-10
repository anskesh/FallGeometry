using Game;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider))]
public class Geometry : MonoBehaviour
{
    public int Score { get; private set; }
    private IMovement _movement;
    private PointGenerator _generator;

    private void Update()
    {
        if (_movement == null)
            return;
        
        if (_generator.OnField(transform.position))
            _movement.Move();
        else
        {
            _movement = null;
            gameObject.SetActive(false);
        }
    }

    public void Initialize(IMovement movement, int score, PointGenerator generator)
    {
        _movement = movement;
        Score = score;
        _generator = generator;
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
