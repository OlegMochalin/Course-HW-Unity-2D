using System.Collections.Generic;
using UnityEngine;

namespace HWRunnerGame
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CherryDisplay _cherryDisplayPrefab;

        private List<CherryDisplay> _cherries = new List<CherryDisplay>();

        private void OnEnable()
        {
            _player.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _player.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            if(_cherries.Count < value)
            {
                float createCherries = value - _cherries.Count;

                for (int i = 0; i < createCherries; i++)
                {
                    CreateCherry();
                }
            }
            else if(_cherries.Count > value)
            {
                float deleteCherries = _cherries.Count - value;

                for (int i = 0; i < deleteCherries; i++)
                {
                    DestroyCherry(_cherries[_cherries.Count - 1]);
                }
            }
        }

        private void DestroyCherry(CherryDisplay cherryDisplay)
        {
            _cherries.Remove(cherryDisplay);
            cherryDisplay.ToDestroy();
        }

        private void CreateCherry()
        {
            CherryDisplay newCherry = Instantiate(_cherryDisplayPrefab, transform);
            _cherries.Add(newCherry);
            newCherry.ToFill();
        }
    }
}