using System;

namespace HomeAppAutomations
{
    static class Timeouts
    {
        public static TimeSpan UiCheckStatusTimeout = TimeSpan.FromMilliseconds(100);
        public static TimeSpan UiInteractionTimeout = TimeSpan.FromSeconds(10);
        public static TimeSpan ShortUiInteractionTimeout = TimeSpan.FromSeconds(5);
        public static TimeSpan LongUiInteractionTimeout = TimeSpan.FromSeconds(30);
        public static TimeSpan LoadingTimeout = TimeSpan.FromSeconds(100);
        public static TimeSpan LongLoadingTimeout = TimeSpan.FromMinutes(10);
    }
}
