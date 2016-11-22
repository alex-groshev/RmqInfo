using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain.Model;
using Infrastructure.Persistence;

namespace RmqInfo
{
    public class ResultViewModel : ObservableObject
    {
        private FormatViewType _formatViewType = new TxtFormatViewType();
        private List<RmqExchange> _exchanges;
        private List<RmqQueue> _queues;
        private string _result;
        private ICommand _lastCommand;

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChangedEvent("Result");
            }
        }

        public ICommand TxtViewCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _formatViewType = new TxtFormatViewType();
                    _lastCommand?.Execute(null);
                });
            }
        }

        public ICommand CsvViewCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _formatViewType = new CsvFormatViewType();
                    _lastCommand?.Execute(null);
                });
            }
        }

        public ICommand TsvViewCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _formatViewType = new TsvFormatViewType();
                    _lastCommand?.Execute(null);
                });
            }
        }

        public ICommand GetExchangesCommand
        {
            get
            {
                _lastCommand = new DelegateCommand(async () => { Result = await GetExchanges(); });
                return _lastCommand;
            }
        }

        public ICommand GetQueuesCommand
        {
            get
            {
                _lastCommand = new DelegateCommand(async () => { Result = await GetQueues(); });
                return _lastCommand;
            }
        }

        private async Task<string> GetExchanges()
        {
            try
            {
                _exchanges = await new RmqExchangeRepository().GetExchangesAsync();
                return ToFormattedString(_exchanges);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<string> GetQueues()
        {
            try
            {
                _queues = await new RmqQueueRepository().GetQueuesAsync();
                return ToFormattedString(_queues);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string ToFormattedString(IEnumerable<RmqExchange> exchanges)
        {
            var result = exchanges.Aggregate(string.Empty,
                (current, c) => current + string.Format(new CustomFormatProvider(), "{0:" + _formatViewType.Format() + "}\n", c));
            if (string.IsNullOrEmpty(result))
                result = "No exchanges";
            return result;
        }

        private string ToFormattedString(IEnumerable<RmqQueue> queues)
        {
            var result = queues.Aggregate(string.Empty,
                (current, c) => current + string.Format(new CustomFormatProvider(), "{0:" + _formatViewType.Format() + "}\n", c));
            if (string.IsNullOrEmpty(result))
                result = "No queues";
            return result;
        }
    }
}
