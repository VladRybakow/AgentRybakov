﻿using AgentSession1Rybakov.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AgentSession1Rybakov.Windows
{
    public partial class AgentInsertWindow : Window
    {
        public static AgentsDBEntities dBEntities = new AgentsDBEntities();
        public AgentInsertWindow()
        {
            InitializeComponent();
        }
    }
}
