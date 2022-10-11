using System;
using Game;
using Game.Observer;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider))]
public class Geometry : MonoBehaviour, Observable
{
    private int _score;
    private IMovement _movement;
    private IMovement _lastMovement;
    private PointGenerator _generator;
    public event Action<int> GainScore;

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
        _score = score;
        _generator = generator;
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        GainScore?.Invoke(_score);
    }

    private void ChangeMove()
    {
        (_lastMovement, _movement) = (_movement, _lastMovement);
    }

    public void OnNotify()
    {
        ChangeMove();
    }
}
