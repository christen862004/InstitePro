namespace InstitePro.Models
{
    public class TestClass
    {
       public void MEthod1()
        {
            int x = 10;
            Method2();//-----------------
            int y = x + 10;
        }
       public  void Method2()
        {
            int z;
        }
        public void MEthod3()
        {
            Method2();

        }


        private int x;

        public int Prop1
        {
            get { return x; }
            set { x = value; }
        }
        //dynamic object
        public dynamic Prop2
        {
            get { return Prop1; }
            set { Prop1 = value; }
        }





        public List<int> list1= new List<int>();
        public dynamic Add(int  x,int y)
        {
            dynamic z = 10;
            dynamic cc = "hello";
            dynamic obj = new Student();
            obj=z + cc;
            //            x + y;
            return z;
            obj=z + cc;
        }
        public void testAdd()
        {
            int a = 10;
            int b = 20;
            Add(a, b);
        }
    }
    public class test2
    {
        void testref()
        {
            TestClass c1 = new TestClass();
            TestClass c2 = new TestClass();
        }
    }
}
