using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private CancellationTokenSource token = new CancellationTokenSource();
        private CancellationTokenSource token1 = new CancellationTokenSource();
        private CancellationTokenSource token2 = new CancellationTokenSource();




        private void btnStart_Click(object sender, RoutedEventArgs e)
      
        {
            if (token == null)
            token = new CancellationTokenSource();
            

            Task.Factory.StartNew(() => Conteggio(token,10000, lblRisposta));
        }
        
        private void Conteggio(CancellationTokenSource token,int max, Label lbl)
        {
            for(int i = 0; i <= max; i++)
            {
               
                Dispatcher.Invoke(()=>AggiornaUI(i,lbl));
                Thread.Sleep(1000);
                Dispatcher.Invoke(() => AggiornaUI1(lbl));
                Thread.Sleep(1000);
                if (token.Token.IsCancellationRequested)
                    break;
            }
            Dispatcher.Invoke(() => AggiornaUI2(lbl));
        }

        private void AggiornaUI(int i, Label lbl)
        {
            lbl.Content = $"sto contando...{i.ToString()}";
        }


        private void AggiornaUI1(Label lbl)
        {
            lbl.Content = "sto aspettando...";

        }

        private void AggiornaUI2(Label lbl)
        {
            lbl.Content = "Ho Finito";

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (token != null)
            {
                token.Cancel();
                token = null;
            }
            
        }

        private void btnStart1_Click(object sender, RoutedEventArgs e)
        {
            int max=Convert.ToInt32(txtCount.Text);
            if (token1 == null)
                token1 = new CancellationTokenSource();

            Task.Factory.StartNew(() => Conteggio(token1,max,lblRisposta2));
        }

        private void btnStop1_Click(object sender, RoutedEventArgs e)
        {
            if (token1 != null)
            {
                token1.Cancel();
                token1 = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int max = Convert.ToInt32(txtMax.Text);
            int delay = Convert.ToInt32(txtDelay.Text);
            if (token2 == null)
                token2 = new CancellationTokenSource();

            Task.Factory.StartNew(() => ConteggioDelay(token2,max, delay, lblRisposta3));
        }

        private void ConteggioDelay(CancellationTokenSource token,int max, int delay, Label lbl)
        {
            for (int i = 0; i <= max; i++)
            {

                Dispatcher.Invoke(() => AggiornaUI(i, lbl));
                Thread.Sleep(delay);
                Dispatcher.Invoke(() => AggiornaUI1(lbl));
                Thread.Sleep(delay);
                if (token.Token.IsCancellationRequested)
                    break;
            }
            Dispatcher.Invoke(() => AggiornaUI2(lbl));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (token2 != null)
            {
                token2.Cancel();
                token2 = null;
            }
        }

        private void btnStopTT_Click(object sender, RoutedEventArgs e)
        {
            if(token != null&& token1 != null&& token2 != null)
            {
                token.Cancel();
                token = null;
                token1.Cancel();
                token1 = null;
                token2.Cancel();
                token2 = null;
            }
        }

        //private void Conteggio1(CancellationTokenSource token,int max,Label lbl)
        //{

        //    for (int i = 0; i <= max; i++)
        //    {

        //        Dispatcher.Invoke(() => AggiornaUI(i,lbl));
        //        Thread.Sleep(1000);
        //        Dispatcher.Invoke(() => AggiornaUI1(lbl));
        //        Thread.Sleep(1000);
        //        if (token.Token.IsCancellationRequested)
        //            break;
        //    }
        //    Dispatcher.Invoke(() => AggiornaUI2(lbl));
        //}
    }
}
