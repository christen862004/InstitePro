namespace InstitePro.Models
{
    public class TestClass
    {
        public void Add(int  x,int y)
        {
            dynamic z = 10;
            dynamic cc = "hello";
            dynamic obj = new Student();
            obj=z + cc;
//            x + y;
        }
        public void testAdd()
        {
            int a = 10;
            int b = 20;
            Add(a, b);
        }
    }
}
