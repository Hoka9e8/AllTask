using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Codes
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        public event Action<string, Color> OnCaugthPlayerChange = delegate(string str, Color color) { };
        private float _lengthFly;
        private float _speedRotation;
        
        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 4.0f);
            _speedRotation = Random.Range(20.0f, 40.0f);
        }

        protected override void Interaction()
        {
            OnCaugthPlayerChange.Invoke(gameObject.name, _color);
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }
            Fly();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}