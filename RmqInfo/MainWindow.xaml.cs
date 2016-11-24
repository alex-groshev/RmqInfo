using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            DataContext = new ResultViewModel();
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
    }
}
