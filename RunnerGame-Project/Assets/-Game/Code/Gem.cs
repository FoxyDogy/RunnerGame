using System;
using _Game.Code.Abstract;
using _Game.Code.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Code
{
    public class Gem : DataBehaviour, Iinteractable
    {
        public ParticleSystem collectParticle;

        private float k;
        private Vector3 startPosition;

        private void Awake()
        {
            startPosition = transform.position;

            k = Random.Range(0.1f, 0.2f);
        }


        private void Update()
        {
            Animation();
        }

        public void Interact(Action action = null)
        {
            var gemValuePerPiece = Data.GetGemValue(Data.currentUserData.gemUpgradeLevel);
            CoinManager.Instance.AddCoin(gemValuePerPiece);
            collectParticle.Play();
            collectParticle.transform.SetParent(null);
            Destroy(gameObject);
            Destroy(collectParticle.gameObject, 1);
        }

        public void Animation()
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);

            transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time) * k,
                transform.position.z);
        }
    }
}