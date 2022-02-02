using System;

namespace Vriendly.Events.UI
{
    public enum LoginType
    {
        EMAIL,
        GOOGLE
    }
    public enum CallbackStatus
    {
        SUCCESS,
        FAILURE
    }
    public static class LoginEvents 
    {
        public static Action<LoginType,string,Action<CallbackStatus,string>> Login;
    }
}
