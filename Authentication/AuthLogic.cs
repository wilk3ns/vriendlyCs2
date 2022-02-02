using UnityEngine;
using Vriendly.Events.Models;
using Vriendly.Events.UI;
using Vriendly.Events.BL;
using System;

namespace Vriendly.Authentication
{
    public static class Auth
    {
        public static void Init()
        {
            new Google().Initiate();
            new Email().Initiate();
        }
        public static void Release()
        {
            new Google().Release();
            new Email().Release();
        }

    }


    public class Google : LoginProvider
    {
        public override void Initiate()
        {
            LoginEvents.Login += Login;
        }
        protected override void Login(LoginType type, string jsonCredentials,Action<CallbackStatus,string> callback)
        {
            if (type != LoginType.GOOGLE)
                return;
        }
        public override void Release()
        {
            LoginEvents.Login -= Login;
        }
    }

    public class Email : LoginProvider
    {
        public override void Initiate()
        {
            LoginEvents.Login += Login;
        }
        protected override void Login(LoginType type, string jsonCredentials, Action<CallbackStatus, string> callback)
        {
            if (type != LoginType.EMAIL)
                return;
            var creds = JsonUtility.FromJson<EmailModel>(jsonCredentials);
            //APICALL
            RepoEvents.EmailLogin?.Invoke(creds,callback);
        }
        public override void Release()
        {
            LoginEvents.Login -= Login;
        }
    }

    public abstract class LoginProvider
    {
        public abstract void Initiate();

        protected abstract void Login(LoginType type, string jsonCredentials, Action<CallbackStatus, string> callback);

        public abstract void Release();
    }
}
