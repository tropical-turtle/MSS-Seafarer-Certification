using System;
using Xunit;
using Bunit;
using CDNApplication.TCComponents;
using CDNApplication.TestHelper;
using CDNApplication.Pages;
using System.Linq;
using AngleSharp.Diffing.Extensions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Test
{
    public class ComponentTestWith_bUnit
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



        // Following test illistrates how we can pass public parameters to a component when testing with bUnit.
        // Also show how to reference the type of the generic item.
        // this link has info about passing parameters in bUnit test
        // https://bunit.egilhansen.com/docs/csharp-based-testing.html


        [Fact]
        public void TSelectTest()
        {
            var context = new TestContext();
            List<Country> CountriesToPopulate = new List<Country>()
            {
                new Country { Id = 1, Text = "Canada" },
                new Country { Id = 2, Text = "USA" },
                new Country { Id = 3, Text = "UK" },
                new Country { Id = 4, Text = "Mexico" }
            };

            var markup = context.RenderComponent<CDNApplication.TCComponents.TSelect<Country>>
                (
                    ("Items", CountriesToPopulate),
                    ("FieldName", "Text")
                ); 


            var allOptionElements = markup.FindAll("option");


            List<string> listOfCountriesInsideSelectionTag = new List<string>();
            foreach(var option in allOptionElements)
            {
                listOfCountriesInsideSelectionTag.Add(option.InnerHtml);
            }


            bool allExpectedOptionsNormal = isCountryOptionPopulated(CountriesToPopulate, listOfCountriesInsideSelectionTag);
            
            Assert.True(allExpectedOptionsNormal);

        }



        private bool isCountryOptionPopulated(List<Country> countriesPassedAsParameter, List<string> expectedCountries )
        {
            bool isPopulated = true;
            for (int n = 0; n < 4; n++)
            {
                if (countriesPassedAsParameter[n].Text != expectedCountries[n])
                {
                    isPopulated = false;
                    break;
                }
            }
            return isPopulated;
        }


        // following class is used by TSElect Test
        public class Country
        {
            public int Id { get; set; }
            public string Text { get; set; }
        }
    }





}
