 using System;
 using System.Data;
 using System.Data.SqlClient;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.specs
 {   
     public class SomeBigMessyComponentSpecs
     {
         public abstract class concern : Observes<SomeBigMessyComponent>
         {
        
         }

         [Subject(typeof(SomeBigMessyComponent))]
         public class when_told_to_do_something_that_cannot_be_tested : concern
         {
             Establish c = () =>
             {
                 the_correct_connection_string = "blah";
                 messy_component = new OurMessyTestComponent();
                 connection_created_by_factory_method = new SqlConnection();
                 
                 provide_a_basic_sut_constructor_argument<ConnectionStringResolver>(new OurFakeResolver(the_correct_connection_string));
                 provide_a_basic_sut_constructor_argument<Func<string,IDbConnection>>(x =>
                 {
                     connection_string_used = x;
                     connection_was_created = true;
                     return connection_created_by_factory_method;
                 });
                 provide_a_basic_sut_constructor_argument<MessyComponent>(messy_component);

             };
             Because b = () =>
                 sut.do_something_that_will_be_difficult_to_test();

             It should_use_the_connection_factory_to_create_the_connection = () =>
             {
                 connection_was_created.ShouldBeTrue();
                 connection_string_used.ShouldEqual(the_correct_connection_string);
             };

             It should_tell_the_messy_component_to_do_something_with_the_created_connection = () =>
             {
                 messy_component.the_connection.ShouldEqual(connection_created_by_factory_method);
             };
  

             static bool connection_was_created;
             static string connection_string_used;
             static string the_correct_connection_string;
             static OurMessyTestComponent messy_component;
             static IDbConnection connection_created_by_factory_method;
         }
     }

     class OurFakeResolver : ConnectionStringResolver
     {
         string value_to_return;

         public OurFakeResolver(string value_to_return)
         {
             this.value_to_return = value_to_return;
         }

         public string get_the_connection_string()
         {
             return value_to_return;
         }
     }

     class OurMessyTestComponent : MessyComponent
     {
         public IDbConnection the_connection { get; set; }
         public void do_something_with(IDbConnection connection)
         {
             the_connection = connection;
         }
     }
 }
