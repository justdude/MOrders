using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MOrders
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SQLite sql;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void okButton1_Click(object sender, RoutedEventArgs e)
        {
            string baseName="base.mdb";

            sql = new SQLite();
            if (!sql.Connect(baseName))
            {
                sql.CreateBase(baseName);
                sql.Connect(baseName);
            }
            else sql.Connect(baseName);


         
          
         /*   sql.ExecuteCommand("INSERT INTO [Costumer]([photo],[fio],[adress],[projectsList]) VALUES ('sdf','ivan','scorohodova',12)");
            sql.ExecuteCommand(@"SELECT * FROM [Costumer]");

           // sql.GetTable();
            
            while (sql.reader.Read())
                textBox1.Text += sql.reader.GetString(0) + Environment.NewLine;
            sql.Disconnect();
          */
        }
    }
}
