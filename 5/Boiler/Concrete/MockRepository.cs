﻿using System;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Dnx.Runtime;


namespace Boiler
{
    public class MockRepository : IBoilerRepository
    {
        private IBoiler _boiler;
        private DateTime _lastRecorded;
        public int _saveCalledCount;
        public int _retrieveCalledCount;

        public MockRepository()
        {
            _boiler = new Boiler();
            _boiler.ActualTemp = 10;
            _boiler.TargetTemp = 20;

            _saveCalledCount = 0;
            _retrieveCalledCount = 0;

            _lastRecorded = DateTime.Now;
        }

        public IBoiler Retrieve()
        {
            _retrieveCalledCount++;
            return _boiler;
        }

        public IBoiler Save(IBoiler boiler)
        {
            _saveCalledCount++;

            _boiler = boiler;

            // fudge to make the clock tick.
            decimal diffInSeconds = (decimal)((DateTime.Now - _lastRecorded).TotalSeconds);
            boiler.ActualTemp = boiler.ActualTemp + (diffInSeconds * (boiler.IsElementOn == false ? -1 : 1));
            _lastRecorded = DateTime.Now;

            return this.Retrieve();
        }
        
       

    }
}