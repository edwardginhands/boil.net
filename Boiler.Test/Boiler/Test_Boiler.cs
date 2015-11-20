using System;
using Xunit;

namespace Boiler.Test
{
    public class Test_Boiler
    {
        [Theory]
        [InlineData(true, false, false, false, 99, 99, 99, true),
         InlineData(false, true, true, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsElementOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp,bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsElementOn, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 99, 99, true),
         InlineData(true, false, true, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsPumpOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsPumpOn, Expected);
        }

        [Theory]
        [InlineData(false, false, true, false, 99, 99, 99, true),
         InlineData(true, true, false, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsBurstOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsBurstOn, Expected);
        }

        [Theory]
        [InlineData(false, false, false, true, 99, 99, 99, true),
        InlineData(true, true, true, false, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsAuto(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsAuto, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 0, 99, 99, 0),
        InlineData(true, false, true, true, 99, 0, 0, 99)]
        public void ConstructorSetsCorrect_TargetTemp(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.TargetTemp, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 0, 99, 0),
        InlineData(true, false, true, true, 0, 99, 0, 99)]
        public void ConstructorSetsCorrect_TempOffset(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.TempOffset, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 99, 0, 0),
        InlineData(true, false, true, true, 0, 0, 99, 99)]
        public void ConstructorSetsCorrect_ActualTemp(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.ActualTemp, Expected);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_IsElementOn()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.IsElementOn, false);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_IsPumpOn()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.IsPumpOn, false);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_IsBurstOn()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.IsBurstOn, false);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_IsAuto()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.IsAuto, false);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_TargetTemp()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.TargetTemp, 0);
        }

        [Fact]
        public void DefaultConstructor_HasCorrectParameters_TempOffset()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.TempOffset, 0);
        }

        [Fact]
        public void DefaultConstructorHasCorrectParameters_ActualTemp()
        {
            Boiler b = new Boiler();
            Assert.Equal(b.ActualTemp, 0);
        }


    }
}
