using MobileAutomation.PageObjects;
using MobileAutomation.Steps;
using System.Collections.Generic;

namespace MobileAutomation.Tools
{
    static class AutomationContext
    {
        public static Dictionary<string, object> Data = new Dictionary<string, object>();
        public static Dictionary<string, BasePage> Pages = new Dictionary<string, BasePage>();
        private static Dictionary<string, BaseSteps> steps = new Dictionary<string, BaseSteps>();

        public static Dictionary<string, BaseSteps> Steps => steps;
        public static void InitializeSteps()
        {
            
            InitializeApiSteps();
        }

        public static void InitializeApiSteps()
        {
            if (!steps.ContainsKey("APISteps"))
                steps["APISteps"] = new APISteps();
        }
    }
}
