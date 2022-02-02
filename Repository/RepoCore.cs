using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vriendly.Repository
{
    public class RepoCore : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Awake()
        {
            Repo.Init();
        }

        private void OnDestroy()
        {
            Repo.Release();
        }
    }
}
