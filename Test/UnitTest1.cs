using System;
using Xunit;
using Bunit;
using CDNApplication.TCComponents;
using CDNApplication.TestHelper;
using CDNApplication.Pages;
using System.Linq;
using AngleSharp.Diffing.Extensions;


namespace Test
{
    public class UnitTest1
    {

        [Fact]
        public void TCInputExtensionTest()
        {
            // TCInputExtension
            string valueEntered_on_TestElement = "Hello Razor";
            string valueFetchedFrom_tcElement = "";

            var context = new TestContext();

            var markup = context.RenderComponent<TCInputExtension>();

            var firstInputElement = markup.Find("input");
            firstInputElement.Input(valueEntered_on_TestElement);

            // after entering value into the first Input element, we need to look for all input elements again.
            // when we get all input elements, Domtree gets refresh, and at this time the value of the first Input element
            // gets transferred to the second one.


            var allInputElements = markup.FindAll("input");
            var tcInputTextElement = allInputElements.ElementAt(1);


            valueFetchedFrom_tcElement = tcInputTextElement.Attributes["value"].Value;

            Assert.Equal(valueEntered_on_TestElement, valueFetchedFrom_tcElement);

        }




    }
}
