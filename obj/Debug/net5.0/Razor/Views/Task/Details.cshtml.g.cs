#pragma checksum "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_Details), @"mvc.1.0.view", @"/Views/Task/Details.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\_ViewImports.cshtml"
using todolist

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\_ViewImports.cshtml"
using todolist.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb25", @"/Views/Task/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6cd59bce72c81f04b375439d56ad2b97790a83b8d8302bdeafb42c0879612ba8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Task_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<todolist.Models.TaskItem>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UploadDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
            Write(
#nullable restore
#line 3 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
     Model.Title

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</h1>\r\n\r\n<p>Due Date: ");
            Write(
#nullable restore
#line 5 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
              Model.DueDate.ToShortDateString()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n<p>Priority: ");
            Write(
#nullable restore
#line 6 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
              Model.Priority

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n<p>Category: ");
            Write(
#nullable restore
#line 7 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
              ViewBag.CategoryName

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n<p>Completed: ");
            Write(
#nullable restore
#line 8 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                Model.IsCompleted ? "Yes" : "No"

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n\r\n<h5>Comments</h5>\r\n\r\n\r\n\r\n<ul>\r\n");
#nullable restore
#line 15 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
     foreach (var comment in Model.Comments)
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <li>\r\n            <p>");
            Write(
#nullable restore
#line 18 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                comment.CommentText

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</p>\r\n            <small>");
            Write(
#nullable restore
#line 19 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                    comment.CreatedAt.ToString("g")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</small>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2510002", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"commentId\"");
                BeginWriteAttribute("value", " value=\"", 579, "\"", 605, 1);
                WriteAttributeValue("", 587, 
#nullable restore
#line 21 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                                              comment.CommentId

#line default
#line hidden
#nullable disable
                , 587, 18, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-warning btn-sm\">Edit</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n           >\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2512414", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"commentId\"");
                BeginWriteAttribute("value", " value=\"", 870, "\"", 896, 1);
                WriteAttributeValue("", 878, 
#nullable restore
#line 27 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                                              comment.CommentId

#line default
#line hidden
#nullable disable
                , 878, 18, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"taskId\"");
                BeginWriteAttribute("value", " value=\"", 952, "\"", 969, 1);
                WriteAttributeValue("", 960, 
#nullable restore
#line 28 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                                           Model.Id

#line default
#line hidden
#nullable disable
                , 960, 9, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 32 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("</ul>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2515547", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"taskId\"");
                BeginWriteAttribute("value", " value=\"", 1196, "\"", 1213, 1);
                WriteAttributeValue("", 1204, 
#nullable restore
#line 36 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                               Model.Id

#line default
#line hidden
#nullable disable
                , 1204, 9, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <textarea name=\"commentText\" required></textarea>\r\n    <button type=\"submit\">Add Comment</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<h5>Documents</h5>\r\n<ul>\r\n");
#nullable restore
#line 46 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
     if (Model.Documents != null && Model.Documents.Any())
    {
        

#line default
#line hidden
#nullable disable

#nullable restore
#line 48 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
         foreach (var doc in Model.Documents)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <li>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1526, "\"", 1550, 1);
            WriteAttributeValue("", 1533, 
#nullable restore
#line 51 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                          doc.DocumentPath

#line default
#line hidden
#nullable disable
            , 1533, 17, false);
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">View Document</a>\r\n                <small>Uploaded on: ");
            Write(
#nullable restore
#line 52 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                     doc.UploadedAt.ToString("g")

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</small>\r\n\r\n                <!-- Delete Document Form -->\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2519259", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"documentId\"");
                BeginWriteAttribute("value", " value=\"", 1859, "\"", 1882, 1);
                WriteAttributeValue("", 1867, 
#nullable restore
#line 56 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                                                   doc.DocumentId

#line default
#line hidden
#nullable disable
                , 1867, 15, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"taskId\"");
                BeginWriteAttribute("value", " value=\"", 1942, "\"", 1959, 1);
                WriteAttributeValue("", 1950, 
#nullable restore
#line 57 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                                               Model.Id

#line default
#line hidden
#nullable disable
                , 1950, 9, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 61 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
        }

#line default
#line hidden
#nullable disable

#nullable restore
#line 61 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
         
    }
    else
    {

#line default
#line hidden
#nullable disable

            WriteLiteral("        <p>No documents available.</p>\r\n");
#nullable restore
#line 66 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
    }

#line default
#line hidden
#nullable disable

            WriteLiteral("</ul>\r\n\r\n\r\n\r\n<h5>Upload Document</h5>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2522904", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" name=\"taskId\"");
                BeginWriteAttribute("value", " value=\"", 2337, "\"", 2354, 1);
                WriteAttributeValue("", 2345, 
#nullable restore
#line 73 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                               Model.Id

#line default
#line hidden
#nullable disable
                , 2345, 9, false);
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input type=\"file\" name=\"document\" />\r\n    <button type=\"submit\">Upload</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<p>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2525257", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 80 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                    Model.Id

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9417a34b604f2543f517db0241dd511898da4dd08b349dedfc5a2a52ff09eb2527537", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 81 "C:\Users\ArchitSinha\source\repos\todolist\todolist\Views\Task\Details.cshtml"
                                     Model.Id

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</p>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<todolist.Models.TaskItem> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
