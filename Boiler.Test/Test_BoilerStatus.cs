using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerStatus
    {

        [Theory]
        [InlineData(true, false, false, false, 99, 99, 99, true),
        InlineData(false, true, true, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsElementOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsElementOn, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 99, 99, true),
        InlineData(true, false, true, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsPumpOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsPumpOn, Expected);
        }

        [Theory]
        [InlineData(false, false, true, false, 99, 99, 99, true),
        InlineData(true, true, false, true, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsBurstOn(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsBurstOn, Expected);
        }

        [Theory]
        [InlineData(false, false, false, true, 99, 99, 99, true),
        InlineData(true, true, true, false, 99, 99, 99, false)]
        public void ConstructorSetsCorrect_IsAuto(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, bool Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.IsAuto, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 0, 99, 99, 0),
        InlineData(true, false, true, true, 99, 0, 0, 99)]
        public void ConstructorSetsCorrect_ActualTemp(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.TargetTemp, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 0, 99, 0),
                InlineData(true, false, true, true, 0, 99, 0, 99)]
        public void ConstructorSetsCorrect_TargetTemp(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.TempOffset, Expected);
        }

        [Theory]
        [InlineData(false, true, false, false, 99, 99, 0, 0),
                InlineData(true, false, true, true, 0, 0, 99, 99)]
        public void ConstructorSetsCorrect_TempOffset(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp, decimal Expected)
        {
            Boiler b = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            BoilerStatus bs = new BoilerStatus(b);
            Assert.Equal(bs.ActualTemp, Expected);
        }
    }
}
