using Netzplantechnik.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Netzplantechnik
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Process> allProcesses= new ObservableCollection<Process>(); 


        public MainWindow()
        {
            
            InitializeComponent();
            listBox.Items.Clear();
            listBox.ItemsSource = allProcesses;
            EdgeFactory factory = new EdgeFactory();

            Project project = new Project();
            Process A = new Process() { Name = "1", Duration = new TimeSpan(4, 0, 0, 0), EarliestStart = new DateTime(1,1,2), EarliestEnd = new DateTime(1,1,5) };
            Process B = new Process() { Name = "2", Duration = new TimeSpan(2, 0, 0, 0), EarliestStart = new DateTime(1, 1, 2), EarliestEnd = new DateTime(1, 1, 3) };

            Process F = new Process() { Name = "6", Duration = new TimeSpan(8, 0, 0, 0) };
            Process G = new Process() { Name = "7", Duration = new TimeSpan(4, 0, 0, 0) };


            Process J = new Process() { Name = "10", Duration = new TimeSpan(16, 0, 0, 0) };
            Process K = new Process() { Name = "11", Duration = new TimeSpan(8, 0, 0, 0) };


            Process N = new Process() { Name = "14", Duration = new TimeSpan(12, 0, 0, 0) };

            
            allProcesses.Add(A);
            allProcesses.Add(B);
            allProcesses.Add(F);
            allProcesses.Add(G);
            allProcesses.Add(J);
            allProcesses.Add(K);
            allProcesses.Add(N);
            

            #region starting Processes
            Edge AF = factory.createEdge(A, F);
            A.Next.Add(AF);

            Edge BG = factory.createEdge(B, G);
            B.Next.Add(BG);

            project.RootProcesses.Add(A);
            project.RootProcesses.Add(B);
            #endregion


            
            #region regular Process Connections
            F.Previous.Add(AF);

            Edge FJ = factory.createEdge(F, J);
            F.Next.Add(FJ);
            J.Previous.Add(FJ);

            Edge JN = factory.createEdge(J, N);
            J.Next.Add(JN);
            N.Previous.Add(JN);

            G.Previous.Add(BG);

            Edge GK = factory.createEdge(G, K);
            G.Next.Add(GK);
            K.Previous.Add(GK);

            Edge KN = factory.createEdge(K, N);
            K.Next.Add(KN);
            N.Previous.Add(KN);


            #endregion

            project.CalcAllTimes();
            

        }
    }
}
