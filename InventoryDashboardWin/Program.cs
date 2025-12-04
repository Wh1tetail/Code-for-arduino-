using System;
using System.Windows.Forms;

namespace InventoryDashboardWin
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardForm());
        }
    }
}
