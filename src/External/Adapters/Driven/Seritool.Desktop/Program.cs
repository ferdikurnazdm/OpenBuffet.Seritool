using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Seritool.Application.Engine;
using Seritool.Desktop.DependencyInjection;

namespace Seritool.Desktop {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            SeritoolEngine seritoolEngine = DependencyInjection
                .DependencyInjection
                .GetServiceProvider
                .GetRequiredService<SeritoolEngine>();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm(seritoolEngine));
        }
    }
}
