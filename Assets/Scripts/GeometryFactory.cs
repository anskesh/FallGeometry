using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

public abstract class GeometryFactory
{
    protected Geometry Template;
    
    protected int Score;
    protected IMovement Movement;

    protected PointGenerator Generator;
    
    private List<Geometry> _pool = new List<Geometry>();

    public Geometry CreateGeometry()
    {
        Geometry figure;
        
        if (!HasFreeInPool(out figure))
            figure = GameObject.Instantiate(Template);
        else
            figure.gameObject.SetActive(true);

        figure.transform.position = Generator.GetRandomPointToSpawn();
        figure.Initialize(CreateMovement(figure.transform), Score, Generator);
        
        _pool.Add(figure);
        
        return figure;
    }
    
    protected abstract IMovement CreateMovement(Transform transform);
    protected abstract void CreateScore();
    protected abstract void CreateTemplate();

    private bool HasFreeInPool(out Geometry figure)
    {
        figure = _pool.FirstOrDefault(geometry => geometry.gameObject.activeSelf == false);
        
        if (figure)
            return true;
        
        return false;
    }
}
