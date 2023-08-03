using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Booster : ScriptableObject
{
    [SerializeField] public Sprite _icon;
    [SerializeField] private float _duration;
    public float Duration => _duration;

    public abstract void OnAdded(BoosterContainer container);
    public abstract void OnRemoved(BoosterContainer container);


}
