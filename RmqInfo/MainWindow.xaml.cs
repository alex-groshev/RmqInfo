using System;
using System.Linq;
using System.Threading;
using System.Windows;
using Infrastructure.Persistence;

namespace RmqInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string Loading = "Loading...";
        private readonly Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _timer = new Timer(TimerCallbackAsync, null, 0, Timeout.Infinite);
        }

        private async void BtnOverview_Click(object sender, RoutedEventArgs e)
        {
            BtnOverview.IsEnabled = false;
            var caption = BtnOverview.Content;
            BtnOverview.Content = Loading;

            try
            {
                TbResult.Text = await (new RmqOverviewRepository()).GetOverviewAsync();
            }
            catch (Exception ex)
            {
                TbResult.Text = ex.Message;
            }

            BtnOverview.Content = caption;
            BtnOverview.IsEnabled = true;
        }

        private async void BtnClusterName_Click(object sender, RoutedEventArgs e)
        {
            BtnClusterName.IsEnabled = false;
            var caption = BtnClusterName.Content;
            BtnClusterName.Content = Loading;

            try
            {
                TbResult.Text = await (new RmqClusterNameRepository()).GetClusterNameAsync();
            }
            catch (Exception ex)
            {
                TbResult.Text = ex.Message;
            }

            BtnClusterName.Content = caption;
            BtnClusterName.IsEnabled = true;
        }

        private async void BtnNodes_Click(object sender, RoutedEventArgs e)
        {
            BtnNodes.IsEnabled = false;
            var caption = BtnNodes.Content;
            BtnNodes.Content = Loading;

            try
            {
                TbResult.Text = await (new RmqNodesRepository()).GetNodesAsync();
            }
            catch (Exception ex)
            {
                TbResult.Text = ex.Message;
            }

            BtnNodes.Content = caption;
            BtnNodes.IsEnabled = true;
        }

        private async void BtnExchanges_Click(object sender, RoutedEventArgs e)
        {
            BtnExchanges.IsEnabled = false;
            var caption = BtnExchanges.Content;
            BtnExchanges.Content = Loading;

            try
            {
                var exchanges = await (new RmqExchangeRepository()).GetExchangesAsync();

                var result = exchanges.Aggregate(string.Empty, (current, c) => current + c.ToString() + "\n");
                if (string.IsNullOrEmpty(result))
                    result = "No exchanges";

                TbResult.Text = result;
            }
            catch (Exception ex)
            {
                TbResult.Text = ex.Message;
            }

            BtnExchanges.Content = caption;
            BtnExchanges.IsEnabled = true;
        }

        private async void TimerCallbackAsync(object state)
        {
            try
            {
                var connections = await (new RmqConnectionRepository()).GetConnectionsAsync().ConfigureAwait(false);

                var result = connections.Aggregate(string.Empty,
                    (current, c) => current + $"State={c.State}, Connected At={c.ConnectedAt}, User={c.User}, Connection={c.ToString()}\n");
                if (string.IsNullOrEmpty(result))
                    result = "No connections";

                TbConnections.Dispatcher.Invoke(() => { TbConnections.Text = result; });
            }
            catch (Exception ex)
            {
                TbConnections.Dispatcher.Invoke(() => { TbConnections.Text = ex.Message; });
            }
            finally
            {
                _timer.Change(1000, Timeout.Infinite);
            }
        }
    }
}
