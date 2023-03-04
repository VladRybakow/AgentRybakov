using AgentSession1Rybakov.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AgentWindow : Window
    {
        public static AgentsDBEntities dBEntities = new AgentsDBEntities();
        public AgentWindow()
        {
            InitializeComponent();

            AgentLst.ItemsSource = dBEntities.ProductSale.ToList();
            foreach (var serv in AgentWindow.dBEntities.AgentType)
            {
                FilterCB.ItemsSource = dBEntities.AgentType.ToList();

            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var TBSQ = dBEntities.ProductSale.OrderBy(a => a.Agent.Title).ToList();
            TBSQ = TBSQ.Where(a => a.Agent.Title.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            AgentLst.ItemsSource = TBSQ;
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typeName = ((AgentType)FilterCB.SelectedItem).Title;
            var type = AgentWindow.dBEntities.AgentType.Where(x => x.Title == typeName).FirstOrDefault();
            AgentLst.ItemsSource = dBEntities.ProductSale.Where(x => x.Agent.AgentType.Title == typeName).ToList();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedIndex == 0)
            {
                AgentLst.ItemsSource = dBEntities.ProductSale.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AgentLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Agent.Title", ListSortDirection.Ascending));


            }
            else if (SortCB.SelectedIndex == 1)
            {
                AgentLst.ItemsSource = dBEntities.ProductSale.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AgentLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Agent.Title", ListSortDirection.Descending));


            }
            else if (SortCB.SelectedIndex == 2)
            {
                AgentLst.ItemsSource = dBEntities.ProductSale.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AgentLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Product.MinCostForAgent", ListSortDirection.Ascending));

            }
            else if (SortCB.SelectedIndex == 3)
            {
                AgentLst.ItemsSource = dBEntities.ProductSale.ToList();
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AgentLst.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Product.MinCostForAgent", ListSortDirection.Descending));

            }
        }

        private void AddWindowOpen(object sender, RoutedEventArgs e)
        {
            AgentAddWindow adw = new AgentAddWindow();
            adw.Show();
            this.Close();
        }
    }
}
