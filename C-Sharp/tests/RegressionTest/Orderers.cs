using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TestCase> OrderTestCases(IEnumerable<TestCase> testCases)
    {
        return testCases.OrderBy(testCase =>
        {
            var priorityAttribute = testCase.TestMethod.Method.GetCustomAttributes(typeof(PriorityAttribute))
                .FirstOrDefault();
            return priorityAttribute?.GetNamedArgument<int>("Priority") ?? int.MaxValue;
        });
    }

    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        throw new NotImplementedException();
    }
}