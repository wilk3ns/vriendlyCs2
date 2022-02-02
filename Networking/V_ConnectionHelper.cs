using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MasterServerToolkit.MasterServer;

namespace Vriendly.Networking
{

    public class V_ConnectionHelper : ConnectionHelper<V_ConnectionHelper>
    {
        protected override void Awake()
        {
            base.Awake();

            if (Mst.Args.IsProvided(Mst.Args.Names.MasterIp) && Mst.Args.IsProvided(Mst.Args.Names.MasterPort))
            {
                // If master IP is provided via cmd arguments
                serverIP = Mst.Args.AsString(Mst.Args.Names.MasterIp, serverIP);
                // If master port is provided via cmd arguments
                serverPort = Mst.Args.AsInt(Mst.Args.Names.MasterPort, serverPort);
            }
            else
            {

            }
        }
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
