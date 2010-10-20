 
using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetprep.specs
{
    public class DelegateSampleSpecs
    {
        public abstract class concern : Observes
        {

        }

        public delegate void Display(string name);

        public class Greeter {
            public void say_hello_to(string name) {
                Console.Out.WriteLine("Hello {0}".format_using(name));
            }
        }

        public class Cashier {
            public void say_goodby_to(string name) {
                Console.Out.WriteLine("Goodbye {0}".format_using(name));
            }
        }
        [Subject(typeof(Delegate))]
        public class when_playing_with_delegates : concern
        {
            It should_be_able_to_do_some_stuff = () =>
            {
                Display compound_message = delegate(string x)
                {
                    Console.Out.Write("Person {0} has walked into the store", x);
                };

                compound_message += new Greeter().say_hello_to;
                compound_message += new Cashier().say_goodby_to;

                compound_message("JP");

            };
        }


        public delegate void EventHandler(object sender, EventArgs event_args);

    }
}
