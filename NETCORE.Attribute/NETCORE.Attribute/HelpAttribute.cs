using System;
using System.Collections.Generic;
using System.Text;

namespace NETCORE.Attribute
{

    //  AttributeUsage类是另外一个预定义特性类，它帮助我们控制我们自己的定制特性的使用。它描述了一个定制特性如和被使用。 
    //　AttributeUsage有三个属性，我们可以把它放置在定制属性前面。第一个属性是： 


    //　　ValidOn
    //通过这个属性，我们能够定义定制特性应该在何种程序实体前放置。一个属性可以被放置的所有程序实体在AttributeTargets enumerator中列出。通过OR操作我们可以把若干个AttributeTargets值组合起来。 


    //　　AllowMultiple
    //这个属性标记了我们的定制特性能否被重复放置在同一个程序实体前多次。 

    //　　Inherited
    //我们可以使用这个属性来控制定制特性的继承规则。它标记了我们的特性能否被继承。 


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class HelpAttribute : System.Attribute
    {


        public HelpAttribute(String Descrition_in)
        {
            this.description = Descrition_in;
        }


        protected String description;
        public String Description
        {
            get
            {
                return this.description;
            }
        }


    }
}
