﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AlsiUtils.Indicators;

namespace AlsiUtils.Strategies
{
    public class TradeStrategy : Indicator
    {
        private static List<TradeStrategy> _ST = new List<TradeStrategy>();
        private static Parameter_General _p = new Parameter_General();

        public delegate void Triggers_Delegate(List<TradeStrategy> TradeStraterty, int Index);
        public static Triggers_Delegate _Trigger;

        
        public TradeStrategy()
        {

        }
        public TradeStrategy(List<Price> Prices, Parameter_General parameter, DateTime startPeriod, Triggers_Delegate Triggers)
        {
            _p.StopLoss = parameter.StopLoss;
            _p.TakeProfit = parameter.TakeProfit;
            _Trigger = Triggers;
            _p.CloseEndofDay = parameter.CloseEndofDay;

            foreach (Price s in Prices)
            {
                if (s.TimeStamp >= startPeriod)
                {
                    TradeStrategy st = new TradeStrategy
                    {
                        TimeStamp = s.TimeStamp,
                        Price_Open = s.Open,
                        Price_Close = s.Close,
                        Price_High = s.High,
                        Price_Low = s.Low,
                        InstrumentName = s.InstrumentName
                    };
                    _ST.Add(st);
                }
            }

        }

        public List<TradeStrategy> getStrategyList()
        {
            return _ST;
        }

        public void Calculate()
        {
            Prepare();
            Triggers();

            PositionAndDirection();
            TradeSignals();


            CalcProfitLoss();
            AddStopLossTriggers();

            Mark();
            ClearProf();

            Triggers();
            PositionAndDirection();
            TradeSignals();
            CalcProfitLoss();

            //  OverNightPosAnalysis();
          

            //  for (int x = 5; x < 100;x++ ) Apply_2nd_AlgoLayer(x);

            /*
                        AddStopLossTriggers();
                        Mark();
                        ClearProf();
                        Triggers();
                        PositionAndDirection();
                        TradeSignals();
                        CalcProfitLoss();
                        */

           
        }

        public void ClearList()
        {
            _ST.Clear();
        }

        private void Prepare()
        {
            _ST[0].Position = false;
            _ST[0].TradeDirection = Trade.Direction.None;
            _ST[0].TradeTrigger = Trade.Trigger.None;


        }

        private void Triggers()
        {
            for (int x = 1; x < _ST.Count; x++)
                if (_ST[x].TradeTrigger == Trade.Trigger.TakeProfit || _ST[x].TradeTrigger == Trade.Trigger.StopLoss ||
                    _ST[x].TradeTrigger == Trade.Trigger.EndOfDayCloseLong || _ST[x].TradeTrigger == Trade.Trigger.EndOfDayCloseShort ||
                    _ST[x].TradeTrigger == Trade.Trigger.ContractExpires
                    ) ;

                else
                {
                    _ST[x].TradeTrigger = Trade.Trigger.None;
                    _Trigger(_ST, x);
                }
        }

        private static void PositionAndDirection()
        {
            for (int x = 1; x < _ST.Count; x++)
            {

                if (_ST[x].TradeTrigger != Trade.Trigger.None)

                    ApplyTradeLogic(_ST, x);
                else
                {
                    _ST[x].Position = _ST[x - 1].Position;
                    _ST[x].TradeDirection = _ST[x - 1].TradeDirection;
                }

                if (_ST[x].TradeTrigger == Trade.Trigger.TakeProfit || _ST[x].TradeTrigger == Trade.Trigger.StopLoss ||
                    _ST[x].TradeTrigger == Trade.Trigger.EndOfDayCloseLong || _ST[x].TradeTrigger == Trade.Trigger.EndOfDayCloseShort ||
                    _ST[x].TradeTrigger == Trade.Trigger.ContractExpires
                    )
                {
                    _ST[x].TradeDirection = Trade.Direction.None;
                    _ST[x].Position = false;
                }

            }
        }

        private static void ApplyTradeLogic(List<TradeStrategy> ss, int x)
        {
            #region Currently Long or Short




            if (_ST[x - 1].TradeDirection == Trade.Direction.Long)
            {
                switch (_ST[x].TradeTrigger)
                {
                    case Trade.Trigger.CloseLong:
                        _ST[x].TradeDirection = Trade.Direction.None;
                        _ST[x].Position = false;
                        break;

                    case Trade.Trigger.CloseShort:
                        _ST[x].TradeDirection = Trade.Direction.None;
                        _ST[x].Position = false;
                        break;

                    default:
                        _ST[x].TradeDirection = Trade.Direction.Long;
                        _ST[x].Position = true;
                        break;
                }
                return;
            }

            if (_ST[x - 1].TradeDirection == Trade.Direction.Short)
            {
                switch (_ST[x].TradeTrigger)
                {
                    case Trade.Trigger.CloseLong:
                        _ST[x].TradeDirection = Trade.Direction.None;
                        _ST[x].Position = false;
                        break;

                    case Trade.Trigger.CloseShort:
                        _ST[x].TradeDirection = Trade.Direction.None;
                        _ST[x].Position = false;
                        break;

                    default:
                        _ST[x].TradeDirection = Trade.Direction.Short;
                        _ST[x].Position = true;
                        break;
                }
                return;
            }




            #endregion

            #region Currently None

            if (_ST[x - 1].TradeDirection == Trade.Direction.None)
            {
                switch (_ST[x].TradeTrigger )
                {
                    case Trade.Trigger.OpenLong:
                        _ST[x].TradeDirection = Trade.Direction.Long;
                        _ST[x].Position = true;
                        break;

                    case Trade.Trigger.OpenShort:
                        _ST[x].TradeDirection = Trade.Direction.Short;
                        _ST[x].Position = true;
                        break;

                    default:
                        _ST[x].TradeDirection = Trade.Direction.None;
                        _ST[x].Position = false;
                        break;
                }
                return;
            }

            #endregion
        }

        private static void TradeSignals()
        {
            for (int x = 1; x < _ST.Count; x++)
            {
                #region Closing Trades
                if (_ST[x - 1].Position && !_ST[x].Position && _ST[x - 1].TradeDirection == Trade.Direction.Long)
                {
                    switch (_ST[x].TradeTrigger)
                    {
                        case Trade.Trigger.CloseLong:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                        case Trade.Trigger.CloseShort:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                        case Trade.Trigger.StopLoss:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                        case Trade.Trigger.TakeProfit:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                        case Trade.Trigger.EndOfDayCloseLong:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                        case Trade.Trigger.ContractExpires:
                            _ST[x].ActualTrade = Trade.Trigger.CloseLong;
                            _ST[x].TradedPrice = _ST[x].Price_Close;
                            break;

                    }
                }
                else
                    if (_ST[x - 1].Position && !_ST[x].Position && _ST[x - 1].TradeDirection == Trade.Direction.Short)
                    {
                        switch (_ST[x].TradeTrigger)
                        {
                            case Trade.Trigger.CloseLong:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;

                            case Trade.Trigger.CloseShort:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;

                            case Trade.Trigger.StopLoss:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;

                            case Trade.Trigger.TakeProfit:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;

                            case Trade.Trigger.EndOfDayCloseShort:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;

                            case Trade.Trigger.ContractExpires:
                                _ST[x].ActualTrade = Trade.Trigger.CloseShort;
                                _ST[x].TradedPrice = _ST[x].Price_Close;
                                break;
                        }
                    }




                #endregion
                    else
                        #region Open Trades
                        if (!_ST[x - 1].Position && _ST[x].Position)
                        {
                            switch (_ST[x].TradeTrigger)
                            {
                                case Trade.Trigger.OpenLong:
                                    _ST[x].ActualTrade = Trade.Trigger.OpenLong;
                                    _ST[x].TradedPrice = _ST[x].Price_Close;
                                    break;

                                case Trade.Trigger.OpenShort:
                                    _ST[x].ActualTrade = Trade.Trigger.OpenShort;
                                    _ST[x].TradedPrice = _ST[x].Price_Close;
                                    break;
                            }
                        }
                        #endregion
                        else
                        #region Carry Over
                        {
                            if (_ST[x].Reason != Trade.TradeReason.StopLoss || _ST[x].Reason != Trade.TradeReason.TakeProfit ||
                                _ST[x].Reason != Trade.TradeReason.EndOfDayCloseLong || _ST[x].Reason != Trade.TradeReason.EndOfDayCloseShort ||
                                _ST[x].Reason != Trade.TradeReason.ContractExpires)
                            {

                                _ST[x].ActualTrade = Trade.Trigger.None;
                                _ST[x].TradedPrice = _ST[x - 1].TradedPrice;
                            }

                            else
                            {
                                _ST[x].ActualTrade = Trade.Trigger.None;
                                _ST[x].TradedPrice = _ST[x - 1].TradedPrice;
                            }
                        }
                        #endregion

            }
        }

        private static void CalcProfitLoss()
        {
            for (int x = 1; x < _ST.Count; x++)
            {
                if (_ST[x].Position & _ST[x].TradeDirection == Trade.Direction.Long)
                    _ST[x].RunningProfit = _ST[x].Price_Close - _ST[x].TradedPrice;

                if (_ST[x].Position & _ST[x].TradeDirection == Trade.Direction.Short)
                    _ST[x].RunningProfit = _ST[x].TradedPrice - _ST[x].Price_Close;


                if (_ST[x - 1].Position && !_ST[x].Position)
                {
                    if (_ST[x - 1].TradeDirection == Trade.Direction.Long)
                        _ST[x].RunningProfit = _ST[x].Price_Close - _ST[x - 1].TradedPrice;

                    if (_ST[x - 1].TradeDirection == Trade.Direction.Short)
                        _ST[x].RunningProfit = _ST[x - 1].TradedPrice - _ST[x].Price_Close;
                }


            }
        }

        private static void AddStopLossTriggers()
        {
            for (int x = 1; x < _ST.Count; x++)
            {
                if (_ST[x].RunningProfit < _p.StopLoss) _ST[x].Reason = Trade.TradeReason.StopLoss;
                if (_ST[x].RunningProfit > _p.TakeProfit) _ST[x].Reason = Trade.TradeReason.TakeProfit;
                if (_p.CloseEndofDay)
                {
                    if (_ST[x].TimeStamp.Hour == 17 && _ST[x].TimeStamp.Minute == 20 && _ST[x].TradeDirection == Trade.Direction.Long) _ST[x].Reason = Trade.TradeReason.EndOfDayCloseLong;
                    if (_ST[x].TimeStamp.Hour == 17 && _ST[x].TimeStamp.Minute == 20 && _ST[x].TradeDirection == Trade.Direction.Short) _ST[x].Reason = Trade.TradeReason.EndOfDayCloseShort;
                }
                if (_ST[x - 1].InstrumentName != _ST[x].InstrumentName) _ST[x - 1].Reason = Trade.TradeReason.ContractExpires;

            }

        }

        private static void Mark()
        {
            #region Mark Object that is Stoploss or Takeprofit
            for (int x = 1; x < _ST.Count; x++)
            {
                if (_ST[x - 1].Reason != Trade.TradeReason.TakeProfit && _ST[x].Reason == Trade.TradeReason.TakeProfit)
                    _ST[x].markedObjectA = true;

                if (_ST[x - 1].Reason != Trade.TradeReason.StopLoss && _ST[x].Reason == Trade.TradeReason.StopLoss)
                    _ST[x].markedObjectA = true;

                if (_ST[x - 1].Reason != Trade.TradeReason.EndOfDayCloseLong && _ST[x].Reason == Trade.TradeReason.EndOfDayCloseLong)
                    _ST[x].markedObjectA = true;

                if (_ST[x - 1].Reason != Trade.TradeReason.EndOfDayCloseShort && _ST[x].Reason == Trade.TradeReason.EndOfDayCloseShort)
                    _ST[x].markedObjectA = true;

                if (_ST[x - 1].Reason != Trade.TradeReason.ContractExpires && _ST[x].Reason == Trade.TradeReason.ContractExpires)
                    _ST[x].markedObjectA = true;

                if ((_ST[x - 1].Position && _ST[x].Position) && _ST[x - 1].markedObjectA) _ST[x].markedObjectA = true;
                if (!_ST[x - 1].markedObjectA && _ST[x].markedObjectA) _ST[x].markedObjectB = true;


            }
            #endregion
        }

        private static void ClearProf()
        {


            #region Clear
            for (int x = 1; x < _ST.Count; x++)
            {
                _ST[x].markedObjectA = false;
                _ST[x].RunningProfit = 0;
                _ST[x].Position = false;
                _ST[x].TradeDirection = Trade.Direction.None;
                _ST[x].ActualTrade = Trade.Trigger.None;
                _ST[x].TradedPrice = 0;
                _ST[x].TradeTrigger = Trade.Trigger.None;


                if (_ST[x].markedObjectB)
                {
                    if (_ST[x].Reason == Trade.TradeReason.TakeProfit) _ST[x].TradeTrigger = Trade.Trigger.TakeProfit;
                    if (_ST[x].Reason == Trade.TradeReason.StopLoss) _ST[x].TradeTrigger = Trade.Trigger.StopLoss;
                    if (_ST[x].Reason == Trade.TradeReason.EndOfDayCloseLong) _ST[x].TradeTrigger = Trade.Trigger.EndOfDayCloseLong;
                    if (_ST[x].Reason == Trade.TradeReason.EndOfDayCloseShort) _ST[x].TradeTrigger = Trade.Trigger.EndOfDayCloseShort;
                    if (_ST[x].Reason == Trade.TradeReason.ContractExpires) _ST[x].TradeTrigger = Trade.Trigger.ContractExpires;
                }
                _ST[x].Reason = 0;
            }
            #endregion

        }
               

    

    

        public static Trade.BuySell GetBuySell(Trade.Trigger trigger)
        {
            switch (trigger)
            {
                case Trade.Trigger.CloseLong:
                    return Trade.BuySell.Sell;
                    break;

                case Trade.Trigger.CloseShort:
                    return Trade.BuySell.Buy;
                    break;            

                case Trade.Trigger.OpenLong:
                    return Trade.BuySell.Buy;
                    break;

                case Trade.Trigger.OpenShort:
                    return Trade.BuySell.Sell;
                    break;

                case Trade.Trigger.EndOfDayCloseLong:
                    return Trade.BuySell.Sell;
                    break;

                case Trade.Trigger.EndOfDayCloseShort:
                    return Trade.BuySell.Buy;
                    break;
                 
            }
            return Trade.BuySell.None;
        }

        public bool Position { get; set; }
        public Trade.Direction TradeDirection { get; set; }
        public Trade.Trigger TradeTrigger { get; set; }
        public Trade.Trigger ActualTrade { get; set; }
        public Trade.TradeReason Reason { get; set; }
        public double RunningProfit { get; set; }
        public string InstrumentName { get; set; }

        public double TradedPrice { get; set; }
        public bool markedObjectA { get; set; }
        public bool markedObjectB { get; set; }

        public double TotalProfit { get; set; }
        public double TradeCount { get; set; }

     
       
        public class Expansion
        {           
            private static void Apply_2nd_AlgoLayer(int EMA)
            {
                List<VariableIndicator> _st = new List<VariableIndicator>();
                foreach (var t in _ST)
                {
                    if (t.TotalProfit != 0)
                    {
                        VariableIndicator v = new VariableIndicator()
                        {
                            TimeStamp = t.TimeStamp,
                            Value = t.TotalProfit,
                        };
                        _st.Add(v);
                    }
                }

                var ema = Factory_Indicator.createEMA(EMA, _st);
                double newprof = ema[0].CustomValue;
                TradeStrategy mt = null;
                bool cantradeA = false;
                bool cantradeB = false;
                bool closepos = false;
                bool first = true;
                int count = 0;
                foreach (var v in ema)
                {
                    count++;
                    // if (count > 30) break;          

                    if (first) ;
                    mt = _ST.Where(z => z.TimeStamp == v.TimeStamp).First();

                    if (!first) closepos = (mt.ActualTrade == Trade.Trigger.CloseShort || mt.ActualTrade == Trade.Trigger.CloseLong);
                    if (closepos && cantradeA) cantradeB = true;
                    else
                        cantradeB = false;

                    cantradeA = (v.CustomValue > v.Ema);

                    if (!first && closepos && cantradeB) newprof += mt.RunningProfit;

                    //Debug.WriteLine(((cantradeA) ? "**" : "") + ((cantradeB) ? "**" : "") + v.Timestamp + " " + v.CustomValue + " " + v.Ema +
                    //    " TradeA :" + cantradeA + "  TradeB :" + cantradeB + " Prof " + newprof +
                    //    "   " + ((!first && mt != null) ? mt.ActualTrade.ToString() : ""));



                    first = false;
                }

                Debug.WriteLine(EMA + "  " + newprof);
                Debug.WriteLine("----------------------------------------------");


            }

            public static List<Trade> ApplyRegressionFilter(int N,List<Trade> Trades)
            {
                Trades = Statistics.RegressionAnalysis_OnPL(N,Trades);               

                for (int x = N + 1; x < Trades.Count(); x++)
                {
                    if (Trades[x - 2].Extention.Slope < Trades[x - 1].Extention.Slope) Trades[x].Extention.IsSlopeHigherThanPrevSlope = true;
                    if (Trades[x - 1].Extention.Slope > 0) Trades[x].Extention.IsSlopeBiggerZero = true;

                    Trades[x].Extention.OrderVol = 1;
                    if (!Trades[x].Extention.IsSlopeBiggerZero && Trades[x].Extention.IsSlopeHigherThanPrevSlope)
                        Trades[x].Extention.OrderVol = 2;
                   
                                         
                    
                 }

                return Trades;
            }
         
            public static List<Trade> MergeNewTrades(List<Trade>OriginalTrades,List<Trade>ModifiedTrades)
            {
                for (int x = 0; x < OriginalTrades.Count; x++)
                {

                    foreach (var t in ModifiedTrades)
                    {
                        if (OriginalTrades[x].TimeStamp == t.TimeStamp)
                        {
                            OriginalTrades[x] = t;
                            break;
                        }
                    }

                }

                    return OriginalTrades;
            }
        }
    }


}
