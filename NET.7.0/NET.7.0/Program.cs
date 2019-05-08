using System;
using System.Collections.Generic;

namespace NET._7._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //https://blog.csdn.net/wsh31415926/article/details/79907545#c70%E6%96%B0%E7%89%B9%E6%80%A7


            // 以前out变量的声明和初始化是分开的
            //int age;
            //if (int.TryParse("18", out age))
            //{
            //    Console.WriteLine("age: " + age);
            //}

            // C#7.0
            // 1. C#7.0允许直接在方法的调用列表中声明一个out变量
            // 2. 这个变量可以声明成var这种隐式类型
            // 3. 这个变量的作用域范围伸展到if语句块的外部范围
            if (int.TryParse("18", out int age))
            {
                Console.WriteLine("age: " + age);
            }

            if (int.TryParse("90", out var score))
            { // 隐式类型也可以用
                Console.WriteLine("score: " + score);
            }

            age += 1; // 这时候age仍然有效





            // c#7.0
            // 1. C#7.0以前就已经有tuple, 但不是语言层面支持的，而且使用起来没效率
            // 2. C#7.0中使用tuple，需要引入 System.ValueTuple（如果平台不包含的话）
            // 3. 元组成员名可指定，不指定默认Item1,Item2,...
            // 4. 元组是值类型，其元素是公开字段，可修改
            // 5. 元组中元素都相等，则元组相等
            // 6. 元组可用于函数返回多个独立变量，这样不用定义一个struct或class
            // 7. 元组使用场合：

            // 元组成员名默认Item1, Item2
            var name = ("Jack", "Ma");
            (string, string) name1 = ("Jack", "Ma");



            // 指定成员名称为firstName, lastName
            (string firstName, string lastName) name2 = ("Jack", "Ma");



            // 指定成员名称为f, l
            var name3 = (f: "Jack", l: "Ma");



            // 左右同时指定成员名称，右边的忽略
            (string firstName, string lastName) name4 = (f: "Jack", l: "Ma");

            // 返回一个元组
            private (string FirstName, string LastName) GetName()
            {
                return ("Jack", "Ma");
            }
            var name5 = GetName();
            name5.FirstName = "Jack2";
            name5.LastName = "Ma2";

            // 析构元组成员到变量firstName, lastName
            (string firstName, string lastName) = GetName();
            firstName = "Jack2";
            lastName = "Ma2";

            // 析构元组成员到变量f, l
            (string f, string l) = name5;
            f = "Jack2";
            l = "Ma2";

            // 析构元组成员到变量f2, l2
            var (f2, l2) = name5;










            // C#7.0
            // 1. 增加一个占位符_(下划线字符)来表示一个只写的变量，这个变量只能写，不能读。
            //    当想丢弃一个值的时候，可以使用。
            // 2. 他不是实际变量，没有实际存储空间，所以可以多处使用。
            // 3. 一般用于解构元组、调用带out参数的方法、模式匹配，例如:
            //    > 调用一个方法，这个方法带有一个out参数，你根本不使用也不关心这个参数；
            //    > 一个包含多个字段的元组，你只关心其中部分成员，不关心的成员可以使用占位符；
            //    > 模式匹配中, _可以匹配任意表达式；
            // 4. 注意：_也是一个有效的变量标识符，在合理的情景下，_也会作为一个有效变量

            private (string FirstName, string LastName) GetName()
            {
                return ("Jack", "Ma");
            }

            private void GetName(out string FirstName, out string LastName)
            {
                FirstName = "Jack";
                LastName = "Ma";
            }

            // 只关心FirstName， LastName丢弃
            var (firstName, _) = GetName();
            GetName(out var firstName2, out _);

            // 有效变量_
            public void Work(int _)
            {
                _ += 4;
            }









            // C#7.0
            // 模式匹配：匹配一个值是否具有某种特征（例如：是否是某个常量、某个类型、某个变量），
            //          如果是，顺便可将这个值提取到对应特征的新变量中
            // C#7.0中，利用已有的关键字is和switch来扩展，实现模式匹配

            // 具有模式匹配的is表达式：不仅能匹配类型，还能匹配表达式
            public static void TestIs(object o)
            {
                const string IP = "127.0.0.1";

                // 匹配常量
                if (o is IP)
                {
                    Console.WriteLine("o is IP");
                }

                if (o is null)
                {
                    Console.WriteLine("o is null");
                }

                // 匹配类型
                if (o is float)
                {
                    Console.WriteLine($"o is float");
                }

                // 匹配类型，并提取值。检测为true，这时候i会被明确赋值
                if (o is int i)
                {
                    Console.WriteLine($"o is int {i}");
                }
                else
                {
                    return;
                }

                // i仍然有效
                // i变量称为模式变量，和out变量一样，统称为表达式变量，作用域都扩展到了外围
                // 表达式变量的范围扩展到了外围，只有在前面的模式匹配为true是才有效
                // 表达式变量为true时，才给变量明确赋值，这样避免了模式不匹配时访问这些变量
                i++;
                Console.WriteLine($"i is {i}");

                if (o is 4 * 4)
                {
                    Console.WriteLine("o is 4*4");
                }
            }


            string SS = Console.ReadLine();

            Console.WriteLine("SDSSS");

        }



        // 可以模式匹配的switch
        // 1. 原来的switch限制为仅仅是string和数字类型的常量匹配，现在解除了
        // 2. switch按照文本顺序匹配，所以需要注意顺序；
        //   （原来switch的分支只匹配一个所以不需要顺序；而现在可以匹配多个，行为变了）
        // 3. case子句后面可以带模式匹配的表达式
        // 4. default最后执行，也就是其他都不匹配时才执行，不管default语句放在什么位置。
        // 5. 如没有default分支，其他也不匹配，则不执行任何switch块代码，直接执行其后面代码
        // 6. case后带var形式变量的匹配，近似于default
        // 7. case 子句引入的模式变量只在switch块内有效
        public static void TestSwitch(object o)
        {
            switch (o)
            {
                case "127.0.0.1":
                    Console.WriteLine("o is IP");
                    break;
                case float f:
                    Console.WriteLine($"o is float {f}");
                    break;
                case int i when i == 4:
                    Console.WriteLine($"o is int {i} == 4");
                    break;
                case int i:
                    Console.WriteLine($"o is int {i}");
                    break;
                case string s when s.Contains("127"):
                    Console.WriteLine("o is string, contains 127 ");
                    break;
                case string s when s.Contains("abc"):
                    Console.WriteLine("o is string, contains 127 ");
                    break;
                case var a when a.ToString().Length == 0:
                    Console.WriteLine($"{a} : a.ToString().Length == 0");
                    break;
                case null:
                    Console.WriteLine($"o is null");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }












        // C#7.0
        // C#7.0以前的ref只能用于函数参数，现在可以用于本地引用和作为引用返回
        // 1. 需要添加关键字ref，定义引用时需要，返回引用时也需要
        // 2. 引用声明和初始化必须在一起，不能拆分
        // 3. 引用一旦声明，就不可修改，不可重新再定向
        // 4. 函数无法返回超越其作用域的引用

        // 需要添加关键字ref，表示函数返回一个ref int
        public static ref int GetLast(int[] a)
        {
            if (a == null || a.Length < 1)
            {
                throw new Exception("");
            }

            int number = 18;

            // 错误声明: 引用申明和初始化分开是错误的 
            //ref int n1; 
            //n1 = number;

            // 正确声明: 申明引用时必须初始化，声明和初始化在一起
            // 添加关键字ref表示n1是一个引用, 
            ref int n1 = ref number;

            // n1指向number，不论修改n1或number，对双方都有影响，相当于双方绑定了。
            n1 = 19;
            Console.WriteLine($"n1:{n1},  number:{number}");
            number = 20;
            Console.WriteLine($"n1:{n1},  number:{number}");

            // 语法错误，引用不可被重定向到另一个引用
            //n1 = ref a[2];

            // 语法正确，但本质是将a[2]的值赋值给n1引用所指，n1仍指向number
            n1 = a[2];
            Console.WriteLine($"n1:{n1},  number:{number}, a[2]:{a[2]}");
            number = 21;
            Console.WriteLine($"n1:{n1},  number:{number}, a[2]:{a[2]}");


            // --------------------- 引用返回 ------------------------ 

            // 错误：n1引用number，但number生存期限于方法内，故不可返回
            // return ref n1;

            // 正确：n2引用a[2]，a[2]生存期不仅仅限于方法内，所以可以返回。
            ref int n2 = ref a[a.Length - 1];
            return ref n2; // 需要ref返回一个引用
            return ref a[a.Length - 1];  // 也可以直接返回一个引用
        }

        public static void Main(string[] args)
        {
            int[] a = { 0, 1, 2, 3, 4, 5 };

            // x不是一个引用，函数将值赋值给左侧变量x
            int x = GetLast(a);
            Console.WriteLine($"x:{x}, a[2]:{a[a.Length - 1]}");
            x = 99;
            Console.WriteLine($"x:{x}, a[2]:{a[a.Length - 1]} \n");

            // 返回引用，需要使用ref关键字，y是一个引用，指向a[a.Lenght-1]
            ref int y = ref GetLast(a);
            Console.WriteLine($"y:{y}, a[2]:{a[a.Length - 1]}");
            y = 100;
            Console.WriteLine($"y:{y}, a[2]:{a[a.Length - 1]}");

            Console.ReadKey();
        }











        // C#7.0
        // 1. 定义在一个方法体内的函数，称为本地方法
        // 2. 本地方法只在其外部方法体内有效
        // 3. 本地方法可定义在其外部方法的任何地方
        // 4. 外部方法其作用域内参数或变量，都可用于本地方法
        // 5. 本地方法实质被编译为当前类的一个私有成员方法，
        //    但被语言层级限制为只能在其外部方法内使用
        // 6. 由于(5)，所以本地方法和类方法一样，没有特殊限制，异步、泛型、Lambda等都可用
        // 7. 常见用例：给迭代器方法和异步方法提供参数检查，因为这两类方法报告错误比较晚
        public static IEnumerable<int> SubsetOfIntArray(int start, int end)
        {
            if (start < end)
            {
                throw new ArgumentException($"start({start}) < end({end})");
            }
            return Subset();

            IEnumerable<int> Subset()
            {
                for (var i = start; i < end; i++)
                    yield return i;
            }
        }




        // C#7.0
        // 1. 类成员方法体是一句话的，都可以改成使用表达式，使用Lambda箭头来表达
        // 2. C#6.0中，这种写法只适用于只读属性和方法
        // 3. C#7.0中，这种写法可以用于更多类成员，包括构造函数、析构函数、属性访问器等
        public string Name => "小米喂大象"; //只读属性
        public void SetAge(int age) => Age = age; //方法
        public void Log(string msg) => System.Console.WriteLine($"{Name} : {msg}");

        public void Init(string name, string password, int age)
        {
            Name = name;
            Password = password;
            Age = age;
        }
        public User(string name) => Init(name, "", 18); //构造函数
        public User(string name, string password) => Init(name, password, 18);
        public ~User() => System.Console.WriteLine("Finalized"); //析构函数（仅示例）

        public string password;
        public int Password
        { //属性访问器
            get => password;
            set => SetPassword(value);
        }


        // C#7.0
        // 1. c#7.0以前，throw是一个语句，因为是语句，所以在某些场合不能使用。
        //    包括条件表达式、空合并表达式、Lambda表达式等。
        // 2. C#7.0可以使用了, 语法不变，但是可以放置在更多的位置
        public string Name
        {
            get => name;
            set => name = value ??
             throw new ArgumentNullException("Name must not be null");
        }


        // C#7.0
        // 1. 7.0以前异步方法只能返回void、Task、Task<T>，现在允许定义其他类型来返回
        // 2. 主要使用情景：从异步方法返回Task引用，需要分配对象，某些情况下会导致性能问题。
        //        遇到对性能敏感问题的时候，可以考虑使用ValueTask<T>替换Task<T>。


        // C#7.0
        // c#7.0为了增加数字的可读性，增加了两个新特性：二进制字面量(ob开头)、数字分隔符(_)
        int b = 123_456_789; // 作为千单位分隔符
        int c = 0b10101010; // 增加了表示二进制的字面量, 以0b开头
        int d = 0b1011_1010; // 二进制字面量里加入数字分割符号_
        float e = 3.1415_926f; // 其他包括float、double、decimal同样可以使用
        double f = 1.345_234_322_333_567_222_777d;
        decimal g = 1.618_033_988_749_894_586_834_365_638_117_720_309_179M;
        long h = 0xff_42_90_b8; // 在十六进制中使用 





        // C#7.0中async不能用于main方法，7.1可以

        // 以前
        static int Main()
        {
            return DoAsyncWork().GetAwaiter().GetResult();
        }

        // 现在
        static async Task<int> Main()
        {
            return await DoAsyncWork();
        }
        static async Task Main()
        { // 没有返回
            await SomeAsyncMethod();
        }










        // 1. C#7.1以前给一个变量设置缺省值，需要使用default(T), C#7.1因为可以推断表达式
        //    的类型，所以可以直接使用default字面量，编译器推断出与default(T)一样的值
        // 2. default字面量可用于以下任意位置：
        //       变量初始值设定项
        //       变量赋值
        //       声明可选参数的默认值
        //       为方法调用参数提供值
        //       返回语句
        //       expression in an expression bodied member
        //      （使用表达式方法体的成员中的表达式）

        public class User
        {
            public string Name { get; set; } = default;
            public int Age { get; set; } = default;
            public int Score => default;
        }
        public static int Test(string name, int age, int score = default)
        {
            // 以前
            string s1 = default(string);
            var s2 = default(string);
            int i = default(int);
            User u = default(User);

            // 现在
            string s3 = default;
            string s4 = "hello";
            s4 = default;

            return default;
        }

        Test(default, default);





        // c#7.0引入tuple，7.1增强了tuple中元素的命名，可通过推导来完成tuple中元素的命名
        // 使用变量来初始化tuple时，可以使用变量名给tuple中元素命名
        var name = "xm01";
        var age = 18;
        var p = (name: name, age: 18); // 以前，显式命名
        var p2 = (name, age); // 现在，可以推导来命名
        p2.age = 19;

    }
}
