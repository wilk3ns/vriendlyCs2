using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vriendly.Events.Models;
using Vriendly.Events.UI;

namespace Vriendly.Authentication
{
    public class AuthCore : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Auth.Init();

            // After removing this line, method should be renamed as Awake()
            var mod = new EmailModel{email="kamran@vriendly.co",password=""};
            LoginEvents.Login?.Invoke(LoginType.EMAIL, JsonUtility.ToJson(mod),(status, message) => { });
        }

        private void OnDestroy()
        {
            Auth.Release();
        }
    }
}
