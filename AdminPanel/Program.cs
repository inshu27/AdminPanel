﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdminPanel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new questionPaper());
        }
    }
}
