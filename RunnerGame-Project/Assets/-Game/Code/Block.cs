using System.Collections.Generic;
using _Game.Code.Base;
using _Game.Code.Utils;
using Foxy.Utils;
using UnityEngine;

namespace _Game.Code
{
    public class Block : DataBehaviour
    {
        public MeshRenderer groundMesh;
        public List<GameObject> collectables;
        public List<GameObject> gems;
        private bool endlessMode;

        private void Awake()
        {
            Init();
            endlessMode = PlayerPrefsX.GetBool("endlessMode", false);
        }

        private void Update()
        {
            if (!endlessMode) return;
            if (transform.position.z < -5)
            {
                Deactivate();
                EndlessController.Instance.AddToGame(this);
            }
        }

        public void Init()
        {
            for (var i = 0; i < collectables.Count; i++) collectables[i].SetActive(false);

            for (var i = 0; i < gems.Count; i++) gems[i].SetActive(false);

            if (Random.value < 0.75f)
            {
                if (Random.value < 0.5f)
                    gems.RandomElement().SetActive(true);
                else
                    collectables.RandomElement().SetActive(true);
            }
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            Init();
        }

        public Vector3 GetJointPoint()
        {
            var joint = groundMesh.bounds.max;
            joint.x = groundMesh.bounds.center.x;
            var diff = groundMesh.bounds.max - groundMesh.bounds.min;
            joint.z += diff.z;
            return joint;
        }
    }
}