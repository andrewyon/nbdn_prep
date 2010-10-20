 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetprep.infrastructure.searching;
 using nothinbutdotnetprep.specs.utility;
 using nothinbutdotnetprep.tests.utility;

namespace nothinbutdotnetprep.specs
 {   
     public class NotCriteriaSpecs
     {
         public abstract class concern : Observes<Criteria<int>,
                                             NotCriteria<int>>
         {
        
         }

         [Subject(typeof(NotCriteria<int>))]
         public class when_determining_if_it_is_satisfied_by_an_item : concern
         {

             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument<Criteria<int>>(new AnonymousCriteria<int>(x => true));
             };

             Because b = () =>
                 result = sut.is_satisfied_by(2);

             It should_return_the_negated_result_of_its_original_criteria = () =>
                 result.ShouldBeFalse();


             static bool result;
                 
         }
     }
 }
