using Xunit;

namespace Boiler.Test
{
    public class Test_Boiler
    {
        [Theory]
        [InlineData(true, true, true, 0, 0, 0, true),
         InlineData(false, true, true, 0, 0, 0, false),
         InlineData(true, false, false, 0, 0, 0, true),
         InlineData(false, false, false, 0, 0, 0, false),
         InlineData(true, true, true, 99, 99, 99, true),
         InlineData(false, true, true, 99, 99, 99, false),
         InlineData(true, false, false, 99, 99, 99, true),
         InlineData(false, false, false, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsElementOn(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp,bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsElementOn, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, true),
         InlineData(false, true, false, 0, 0, 0, true),
         InlineData(true, false, true, 0, 0, 0, false),
         InlineData(false, true, false, 0, 0, 0, true),
         InlineData(true, true, true, 99, 99, 99, true),
         InlineData(false, true, false, 99, 99, 99, true),
         InlineData(true, false, true, 99, 99, 99, false),
         InlineData(false, true, false, 99, 99, 99, true)]
        public void ConstructorSetsCorrect_IsPumpOn(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsPumpOn, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, true),
         InlineData(false, false, true, 0, 0, 0, true),
         InlineData(false, false, false, 0, 0, 0, false),
         InlineData(false, false, true, 0, 0, 0, true),
         InlineData(true, true, true, 99, 99, 99, true),
         InlineData(false, false, true, 99, 99, 99, true),
         InlineData(false, false, false, 99, 99, 99, false),
         InlineData(false, false, true, 99, 99, 99, true),]
        public void ConstructorSetsCorrect_IsAuto(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.IsAuto, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 99, 0, 0, 99),
         InlineData(false, false, false, 0 ,99, 99, 0)]
        public void ConstructorSetsCorrect_ActualTemp(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.TargetTemp, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 0, 99, 0, 99),
         InlineData(false, false, false, 99, 0, 99, 0)]
        public void ConstructorSetsCorrect_TargetTemp(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            Assert.Equal(b.TempOffset, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 0, 0, 99, 99),
         InlineData(false, false, false, 00, 99, 0, 0)]
        public void ConstructorSetsCorrect_TempOffset(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
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
