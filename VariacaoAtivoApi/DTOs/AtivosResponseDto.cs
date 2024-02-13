using System.Collections.Generic;

namespace VariacaoAtivoApi.DTOs
{
    public class AtivosResponseDto
    {
        public Chart Chart { get; set; }
        public object? Error { get; set; }
    }

    public class Chart
    {
        public List<Result> Result { get; set; }
    }

    public class Result
    {
        public Meta Meta { get; set; }
        public List<long> Timestamp { get; set; }
        public Indicators Indicators { get; set; }
    }

    public class Meta
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
        public string InstrumentType { get; set; }
        public long FirstTradeDate { get; set; }
        public long RegularMarketTime { get; set; }
        public int Gmtoffset { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public decimal RegularMarketPrice { get; set; }
        public decimal ChartPreviousClose { get; set; }
        public int PriceHint { get; set; }
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
        public List<string> ValidRanges { get; set; }
    }

    public class CurrentTradingPeriod
    {
        public TradingPeriod Pre { get; set; }
        public TradingPeriod Regular { get; set; }
        public TradingPeriod Post { get; set; }
    }

    public class TradingPeriod
    {
        public string Timezone { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public int Gmtoffset { get; set; }
    }

    public class Indicators
    {
        public List<Quote> Quote { get; set; }
        public List<AdjClose> Adjclose { get; set; }
    }

    public class Quote
    {
        public List<long> Volume { get; set; }
        public List<decimal> High { get; set; }
        public List<decimal> Low { get; set; }
        public List<decimal> Open { get; set; }
        public List<decimal> Close { get; set; }
    }

    public class AdjClose
    {
        public List<decimal?> Adjclose { get; set; }
    }
}
