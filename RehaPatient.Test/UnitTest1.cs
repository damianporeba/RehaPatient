namespace RehaPatient.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            int a = 5; int b = 6;

            //act
            int c = a + b;
            

            //assert

            Assert.Equal(11, c);

        }
    }
}