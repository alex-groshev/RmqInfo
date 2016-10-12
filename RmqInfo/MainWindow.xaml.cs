using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Domain.Model;
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
        private string _resultFormat = "TXT";

        public MainWindow()
        {
            InitializeComponent();
            _timer = new Timer(TimerCallbackAsync, null, 0, Timeout.Infinite);
        }

        private async void BtnClickHandler(ContentControl button, Func<Task<string>> func)
        {
            button.IsEnabled = false;
            var caption = button.Content;
            button.Content = Loading;

            try
            {
                TbResult.Text = await func.Invoke();
            }
            catch (Exception ex)
            {
                TbResult.Text = ex.Message;
            }

            button.Content = caption;
            button.IsEnabled = true;
        }

        private void BtnOverview_Click(object sender, RoutedEventArgs e)
        {
            BtnClickHandler(BtnOverview, async () => await (new RmqOverviewRepository()).GetOverviewAsync());
        }

        private void BtnClusterName_Click(object sender, RoutedEventArgs e)
        {
            BtnClickHandler(BtnClusterName, async () => await (new RmqClusterNameRepository()).GetClusterNameAsync());
        }

        private void BtnNodes_Click(object sender, RoutedEventArgs e)
        {
            BtnClickHandler(BtnNodes, async () => await (new RmqNodesRepository()).GetNodesAsync());
        }

        private void BtnExchanges_Click(object sender, RoutedEventArgs e)
        {
            Func<Task<string>> func = async () =>
            {
                var exchanges = await (new RmqExchangeRepository()).GetExchangesAsync();
                var result = exchanges.Aggregate(string.Empty,
                    (current, c) => current + string.Format(new CustomFormatProvider(), "{0:" + _resultFormat + "}\n", c));
                if (string.IsNullOrEmpty(result))
                    result = "No exchanges";
                return result;
            };
            BtnClickHandler(BtnExchanges, func);
        }

        private void BtnQueues_Click(object sender, RoutedEventArgs e)
        {
            Func<Task<string>> func = async () =>
            {
                var queues = await (new RmqQueueRepository()).GetQueuesAsync();
                var result = queues.Aggregate(string.Empty,
                    (current, c) => current + string.Format(new CustomFormatProvider(), "{0:" + _resultFormat + "}\n", c));
                if (string.IsNullOrEmpty(result))
                    result = "No queues";
                return result;
            };
            BtnClickHandler(BtnQueues, func);
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

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TbResult.Text);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            _resultFormat = radioButton != null ? (string) radioButton.Content : "TXT";
        }
    }
}
