using Game;
using UnityEngine;

public class Geometry : MonoBehaviour
{
    private IMovement _movement;

    private void Update()
    {
        _movement.Move();
    }
}
