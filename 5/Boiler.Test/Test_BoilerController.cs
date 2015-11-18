using Xunit;

namespace Boiler.Test
{
    public class Test_BoilerController
    {

        [Theory]
        [InlineData(true, true, true, true, 0, 0, 0),
         InlineData(false, true, true, true, 0, 0, 0),
         InlineData(true, false, true, false, 0, 0, 0),
         InlineData(false, false, true, false, 0, 0, 0),
         InlineData(true, true, true, true, 99, 99, 99),
         InlineData(false, true, true, true, 99, 99, 99),
         InlineData(true, false, true, false, 99, 99, 99),
         InlineData(false, false, true, false, 99, 99, 99)]
        public void WhenCallingGetAValidBoilerIsRetreived(bool IsElementOn, bool IsPumpOn,bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            MockRepository repo = new MockRepository();
            Boiler boilerIn = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);
            repo.Save(boilerIn);

            BoilerController controller = new BoilerController(repo);

            Boiler boilerOut = controller.Get();

            Assert.Equal(boilerIn, boilerOut);
        }

        [Theory]
        [InlineData(true, true, true, true, 0, 0, 0),
         InlineData(false, true, true, true, 0, 0, 0),
         InlineData(true, false, true, false, 0, 0, 0),
         InlineData(false, false, true, false, 0, 0, 0),
         InlineData(true, true, true, true, 99, 99, 99),
         InlineData(false, true, true, true, 99, 99, 99),
         InlineData(true, false, true, false, 99, 99, 99),
         InlineData(false, false, true, false, 99, 99, 99)]
        public void WhenCallingPostTheBoilerIsRetreived(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            MockRepository repo = new MockRepository();
            Boiler boilerIn = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);

            BoilerController controller = new BoilerController(repo);

            Boiler boilerOut = controller.Post(boilerIn);

            Assert.Equal(boilerIn, boilerOut);
        }

        [Theory]
        [InlineData(true, true, true, true, 0, 0, 0),
         InlineData(false, true, true, true, 0, 0, 0),
         InlineData(true, false, true, false, 0, 0, 0),
         InlineData(false, false, true, false, 0, 0, 0),
         InlineData(true, true, true, true, 99, 99, 99),
         InlineData(false, true, true, true, 99, 99, 99),
         InlineData(true, false, true, false, 99, 99, 99),
         InlineData(false, false, true, false, 99, 99, 99)]
        public void WhenCallingPostTheBoilerIsSaved(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            MockRepository repo = new MockRepository();
            Boiler boilerIn = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);

            BoilerController controller = new BoilerController(repo);

             controller.Post(boilerIn);

            Boiler boilerSaved = (Boiler)repo.Retrieve();

            Assert.Equal(boilerIn, boilerSaved);
        }

        [Theory]
        [InlineData(true, true, true, true, 0, 0, 0),
         InlineData(false, true, true, true, 0, 0, 0),
         InlineData(true, false, true, false, 0, 0, 0),
         InlineData(false, false, true, false, 0, 0, 0),
         InlineData(true, true, true, true, 99, 99, 99),
         InlineData(false, true, true, true, 99, 99, 99),
         InlineData(true, false, true, false, 99, 99, 99),
         InlineData(false, false, true, false, 99, 99, 99)]
        public void WhenCallingPutTheBoilerIsRetreived(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            MockRepository repo = new MockRepository();
            Boiler boilerIn = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);

            BoilerController controller = new BoilerController(repo);

            Boiler boilerOut = controller.Put(boilerIn);

            Assert.Equal(boilerIn, boilerOut);
        }

        [Theory]
        [InlineData(true, true, true, true, 0, 0, 0),
         InlineData(false, true, true, true, 0, 0, 0),
         InlineData(true, false, true, false, 0, 0, 0),
         InlineData(false, false, true, false, 0, 0, 0),
         InlineData(true, true, true, true, 99, 99, 99),
         InlineData(false, true, true, true, 99, 99, 99),
         InlineData(true, false, true, false, 99, 99, 99),
         InlineData(false, false, true, false, 99, 99, 99)]
        public void WhenCallingPutTheBoilerIsSaved(bool IsElementOn, bool IsPumpOn, bool IsBurstOn, bool IsAuto, decimal TargetTemp, decimal TempOffset, decimal ActualTemp)
        {
            MockRepository repo = new MockRepository();
            Boiler boilerIn = new Boiler(IsElementOn, IsPumpOn, IsBurstOn, IsAuto, TargetTemp, TempOffset, ActualTemp);

            BoilerController controller = new BoilerController(repo);

            controller.Put(boilerIn);

            Boiler boilerSaved = (Boiler)repo.Retrieve();

            Assert.Equal(boilerIn, boilerSaved);
        }

    }
}
