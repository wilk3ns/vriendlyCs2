using System;
using UnityEngine;
using Vriendly.Events.BL;
using Vriendly.Events.Models;
using Vriendly.Events.UI;

namespace Vriendly.Repository
{
    public static class Repo
    {
        static UnitOfWork unit = new UnitOfWork();
        public static void Init()
        {
            new EmailLoginCall().Initiate();
            new GoogleLoginCall().Initiate();
        }
        public static void Release()
        {
            new EmailLoginCall().Release();
            new GoogleLoginCall().Release();
        }

    }

    public class EmailLoginCall : APICall
    {
        public override void Initiate()
        {
            RepoEvents.EmailLogin += LoginWithEmail;
        }

        public override void Release()
        {
            RepoEvents.EmailLogin -= LoginWithEmail;
        }

        private void LoginWithEmail(EmailModel eModel, Action<CallbackStatus, string> callback)
        {
            new UnitOfWork().CheckInternetConnection(5, (connected) =>
             {
                 if (connected)
                     Debug.Log("Login with Email fired " + eModel.email);
                 //Proceed 
                 else
                     callback(CallbackStatus.FAILURE, "No Internet Connection");
             });

        }
    }

    public class GoogleLoginCall : APICall
    {
        public override void Initiate()
        {
            RepoEvents.GoogleLogin += LoginWithGoogle;
        }

        public override void Release()
        {
            RepoEvents.GoogleLogin -= LoginWithGoogle;
        }

        private void LoginWithGoogle(string obj)
        {

        }
    }

    public abstract class APICall
    {
        public abstract void Initiate();
        public abstract void Release();
    }


}
