﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using NSubstitute;

using Ocelot.ConfigEditor;
using Ocelot.ConfigEditor.Editor.Controllers;
using Ocelot.Configuration.Repository;

using Xunit;

namespace Ocelot.ConfigEditorUnitTests.Editor.Controllers.EditorController
{
    public class ContentFileFacts
    {
        private readonly IFileConfigurationRepository _config;

        private readonly IReloadService _reload;

        public ContentFileFacts()
        {
            _config = Substitute.For<IFileConfigurationRepository>();
            _reload = Substitute.For<IReloadService>();
        }

        [Fact]
        public void WhenRequestSiteCss_ReturnCssContentType()
        {
            var controller = new ConfigEditor.Editor.Controllers.EditorController(_config, _reload);

            var css = controller.ContentFile("site.min.css").ContentType;

            Assert.Equal("text/css", css);
        }

        [Fact]
        public void WhenRequestSiteCss_ReturnCssFile()
        {
            var controller = new ConfigEditor.Editor.Controllers.EditorController(_config, _reload);

            var fileStream = controller.ContentFile("site.min.css").FileStream;
            var css = string.Empty;

            using (var reader = new StreamReader(fileStream))
            {
                css = reader.ReadToEnd();
            }

            Assert.NotEqual(string.Empty, css);
        }

        [Fact]
        public void WhenRequestSiteJs_ReturnJsContentType()
        {
            var controller = new ConfigEditor.Editor.Controllers.EditorController(_config, _reload);

            var css = controller.ContentFile("site.min.js").ContentType;

            Assert.Equal("text/javascript", css);
        }

        [Fact]
        public void WhenRequestSiteJs_ReturnJsFile()
        {
            var controller = new ConfigEditor.Editor.Controllers.EditorController(_config, _reload);

            var fileStream = controller.ContentFile("site.min.js").FileStream;
            var css = string.Empty;

            using (var reader = new StreamReader(fileStream))
            {
                css = reader.ReadToEnd();
            }

            Assert.NotEqual(string.Empty, css);
        }
    }
}
