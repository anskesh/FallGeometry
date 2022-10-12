using System;
using Game;
using Game.Observer;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider))]
public class Geometry : MonoBehaviour, Observable
{
    public bool IsMove { get; set; } = true; 
    public event Action<int> GainScore;
    
    private int _score;
    private IMovement _movement;
    private IMovement _originalMovement;
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
        _originalMovement = movement;
        _score = score;
        _generator = generator;
        ChangeMove(true);
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        GainScore?.Invoke(_score);
    }

    private void ChangeMove(bool first = false)
    {
        if (!first)
            IsMove = !IsMove;
        
        if (IsMove)
            _movement = _originalMovement;
        else
            _movement = new NoMovement();
    }

    public void OnNotify()
    {
        ChangeMove();
    }
}
