﻿// Copyright 2016, 2017, 2018 TRUMPF Werkzeugmaschinen GmbH + Co. KG.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Trumpf.Coparoo.Tests
{
    using NUnit.Framework;
    using Trumpf.Coparoo.Web.Controls;

    [TestFixture]
    public class LinkTests : ControlTests
    {
        /// <summary>
        /// Test method.
        /// </summary>
        [Test]
        public void WhenALinkIsAccessed_ThenItCanBeFoundAndThePropertiesFit()
        {
            var text = Random;
            var url = $"http://{Random}/";
            PrepareAndExecute<Tab>(nameof(WhenALinkIsAccessed_ThenItCanBeFoundAndThePropertiesFit), HtmlStart + $"<a href=\"{url}\">{text}</a>" + HtmlEnd, tab =>
            {
                // Act
                var link = tab.Find<Link>();
                var exists = link.Exists.TryWaitFor();
                var linkText = link.Text;
                var linkUrl = link.URL;

                // Check
                Assert.True(exists);
                Assert.AreEqual(text, linkText);
                Assert.AreEqual(url, linkUrl);
            });
        }
    }
}
