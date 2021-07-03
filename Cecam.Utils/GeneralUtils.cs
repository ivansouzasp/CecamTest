using System;
namespace Cecam.Utils
{
    public class GeneralUtils
    {
        public static OperationalSystem GetOperationalSystem()
        {
            var osSelected = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            if (osSelected.Contains("Darwin"))
                return OperationalSystem.MAC;
            else if (osSelected.Contains("Windows"))
                return OperationalSystem.Windows;
            else return OperationalSystem.None;
        }
    }
}
