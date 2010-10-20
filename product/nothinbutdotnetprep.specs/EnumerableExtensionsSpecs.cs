using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.specs.utility;

namespace nothinbutdotnetprep.specs
{
    public class EnumerableExtensionsSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(EnumerableExtensions))]
        public class when_finding_all_items : concern
        {
            Establish c = () => { original_set = ObjectMother.create_from(1, 2, 3, 4, 5, 6, 7); };

            Because b = () =>
                result =
                    original_set.all_items_matching(new AnonymousCriteria<int>(x => x%2 == 0));

            It should_return_all_items_matching_the_provided_condition = () =>
                result.ShouldContain(2, 4, 6);

            static IEnumerable<int> result;
            static IEnumerable<int> original_set;
        }
    }
}