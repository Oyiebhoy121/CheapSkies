using Hello;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange 
            var obj = new Arithmetic();
            int x = 1;
            int y = 2;
            //Act 
            int z = obj.Add(x, y);
            //Assert
            Assert.Equal(3, z);
        }
    }
}