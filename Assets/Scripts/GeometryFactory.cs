using System.Collections.Generic;
using Game;
using UnityEngine;

public abstract class GeometryFactory
{
    protected List<Geometry> Pool;
    protected abstract Sprite CreateForm();
    protected abstract IMovement CreateMovement();
    public abstract Geometry CreateGeometry();
}
