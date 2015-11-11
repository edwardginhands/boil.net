using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerStatus
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
        public void ConstructorSetsCorrect_IsElementOn(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsElementOn, Expected);
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
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsPumpOn, Expected);
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
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsAuto, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 99, 0, 0, 99),
         InlineData(false, false, false, 0, 99, 99, 0)]
        public void ConstructorSetsCorrect_ActualTemp(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.TargetTemp, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 0, 99, 0, 99),
         InlineData(false, false, false, 99, 0, 99, 0)]
        public void ConstructorSetsCorrect_TargetTemp(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.TempOffset, Expected);
        }

        [Theory]
        [InlineData(true, true, true, 0, 0, 0, 0),
         InlineData(false, false, true, 0, 0, 99, 99),
         InlineData(false, false, false, 00, 99, 0, 0)]
        public void ConstructorSetsCorrect_TempOffset(bool IsElementOn, bool IsPumpOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.ActualTemp, Expected);
        }
    }
}
