
using System;
using Vriendly.Repository.Utilities;

namespace Vriendly.Repository
{
    public class UnitOfWork
    {
        public DataContext context;

        public APICall call;

        public void CheckInternetConnection(int numOfAttempts, Action<bool> connected)
        {
            Utils.CheckConnectivity(numOfAttempts, connected);
        }

    }
}
