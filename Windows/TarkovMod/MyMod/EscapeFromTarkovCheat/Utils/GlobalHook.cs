using System;
using EFT;

namespace EscapeFromTarkovCheat.Utils
{
    // Token: 0x0200000C RID: 12
    public static class GlobalHook
    {
        // Token: 0x0600005A RID: 90 RVA: 0x000074E9 File Offset: 0x000056E9
        public static void Initialize(TarkovApplication app)
        {
            GlobalHook.tarkovApplication = app;
        }

        // Token: 0x0400005A RID: 90
        public static TarkovApplication tarkovApplication;
    }
}
