using AgentSession1Rybakov.DB;
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
        ProductSale sale;
        public AgentInsertWindow(ProductSale sale)
        {
            InitializeComponent();
            this.sale = sale;
            AgentDataAll();
        }
        void AgentDataAll()
        {

            TitleTB.Text = Convert.ToString(sale.Agent.Title);
            IdTB.Text = Convert.ToString(sale.ID);
            CountTB.Text = Convert.ToString(sale.Product.ProductionPersonCount);
            PriorityTB.Text = Convert.ToString(sale.Agent.Priority);
            SumTB.Text = Convert.ToString(sale.Product.MinCostForAgent);
            PhoneTB.Text = Convert.ToString(sale.Agent.Phone);
            AgentTypeTB.Text = sale.Agent.AgentType.Title;
        }
        private void RedBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductSale productSale = dBEntities.ProductSale.FirstOrDefault();
            productSale = sale;
            productSale.Agent.Title = TitleTB.Text;
            productSale.Product.ProductionPersonCount = Convert.ToInt32(CountTB.Text);
            productSale.Product.MinCostForAgent = Convert.ToDecimal(SumTB.Text);
            productSale.Agent.Priority = Convert.ToInt32(PriorityTB.Text);
            productSale.Agent.Phone = PhoneTB.Text;

            dBEntities.SaveChanges();
            MessageBox.Show("Отредактированно");
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgentWindow ad = new AgentWindow();
            ad.Show();
            this.Close();
        }
    }
}
