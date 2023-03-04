using AgentSession1Rybakov.DB;
using Microsoft.Win32;
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
    public partial class AgentAddWindow : Window
    {
        public static AgentsDBEntities dBEntities = new AgentsDBEntities();
        OpenFileDialog ofdImage = new OpenFileDialog();
        public AgentAddWindow()
        {
            InitializeComponent();

            AgentTypeCB.ItemsSource = dBEntities.AgentType.ToList();
        }
        private void ImgBtn_Click(object sender, RoutedEventArgs e)
        {
            ofdImage.Filter = "Image files|*.bmp;*.jpg;*.png|All files|*.*";
            ofdImage.FilterIndex = 1;
            if (ofdImage.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdImage.FileName);
                image.EndInit();
                playim.Source = image;
            }
        }
        private void DelImgBtn_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.Freeze();
            playim.Source = image;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTB.Text == "" || TitleTB.Text == "" || PriorityTB.Text == "" || INNTB.Text == "")
            {
                MessageBox.Show("Введите данные!");
            }
            else
            {
                Agent agent = new Agent();
                agent.Title = TitleTB.Text;
                agent.Email = EmailTB.Text;
                agent.INN = INNTB.Text;
                agent.KPP = KPPTB.Text;
                agent.DirectorName = DirectoryNameTB.Text;
                agent.Phone = PhoneTB.Text;
                agent.Priority = Convert.ToInt32(PriorityTB.Text);
                agent.Address = AddressTB.Text;
                var agentType = ((AgentType)AgentTypeCB.SelectedItem).ID;
                agent.AgentTypeID = agentType;
                agent.Logo = null;

                dBEntities.Agent.Add(agent);
                dBEntities.SaveChanges();
                MessageBox.Show("Сохранено!");

            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AgentWindow ad = new AgentWindow();
            ad.Show();
            this.Close();
        }
    }
}
