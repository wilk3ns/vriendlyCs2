using System;
using Vriendly.Events.Models;
using Vriendly.Events.UI;

namespace Vriendly.Events.BL
{
    public class RepoEvents
    {
        public static Action<EmailModel, Action<CallbackStatus, string>> EmailLogin;
        public static Action<string> GoogleLogin;
    }
}
