using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterContainer : MonoBehaviour
{
    // To Control Booster's Flow
    private List<BoosterInstance> _activeBoosters = new List<BoosterInstance>(); 
    public void AddBooster(Booster booster)
    {
        var boosterInstance = new BoosterInstance(booster);
        _activeBoosters.Add(boosterInstance);
    }
    public void RemoveBooster(Booster booster)
    {
        foreach (var instance in _activeBoosters)
        {
            if (instance.Booster = booster)
            {
                instance.RemainingDuration = 0;
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < _activeBoosters.Count; i++)
        {
            var instance = _activeBoosters[i];
            instance.RemainingDuration -= Time.deltaTime;
        }
    }
    public class BoosterInstance
    {
        // Eklenen booster'in kac sn kaldigini tutmak
        public Booster Booster { get; set; }
        public float RemainingDuration { get; set; }
        public BoosterInstance(Booster booster)
        {
            Booster = booster;
            RemainingDuration = Booster.Duration;
        }
    }
}
