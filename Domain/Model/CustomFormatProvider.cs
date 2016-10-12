using System;
using System.Globalization;

namespace Domain.Model
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            return formatType == typeof (ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            int formatType;

            switch (format.ToUpper(CultureInfo.InvariantCulture))
            {
                case "CSV":
                    formatType = 1;
                    break;
                case "TSV":
                    formatType = 2;
                    break;
                default:
                    return arg.ToString();
            }

            var rmqExchange = arg as RmqExchange;
            if (rmqExchange != null)
                return FormatRmqExchange(rmqExchange, formatType);

            var queue = arg as RmqQueue;
            return queue != null ? FormatRmqQueue(queue, formatType) : arg.ToString();
        }

        private static string FormatRmqExchange(RmqExchange xch, int formatType)
        {
            if (formatType == 1)
                return $"{xch.Name},{xch.Vhost},{xch.Type},{xch.Durable},{xch.AutoDelete},{xch.Internal}";

            return formatType == 2
                ? $"{xch.Name}\t{xch.Vhost}\t{xch.Type}\t{xch.Durable}\t{xch.AutoDelete}\t{xch.Internal}"
                : xch.ToString();
        }

        private static string FormatRmqQueue(RmqQueue queue, int formatType)
        {
            if (formatType == 1)
                return $"{queue.Name},{queue.Vhost},{queue.Durable},{queue.AutoDelete},{queue.Exclusive}";

            if (formatType == 2)
                return $"{queue.Name}\t{queue.Vhost}\t{queue.Durable}\t{queue.AutoDelete}\t{queue.Exclusive}";

            return queue.ToString();
        }
    }
}
