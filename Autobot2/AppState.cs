// AppState.cs
using System;

namespace Autobot2
{
    public static class AppState
    {
        public static OBD2Manager OBD { get; private set; }
        public static bool IsConnected => OBD?.IsConnected ?? false;

        public static event Action ConnectionChanged;

        public static void SetOBD(OBD2Manager obd)
        {
            OBD = obd;
            ConnectionChanged?.Invoke();
        }

        public static void ClearOBD()
        {
            OBD?.StopPolling();
            OBD?.Disconnect();
            OBD = null;
            ConnectionChanged?.Invoke();
        }
    }
}