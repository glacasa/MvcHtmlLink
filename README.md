MvcHtmlLink
===========

![Build status](https://glacasa.visualstudio.com/DefaultCollection/_apis/public/build/definitions/c7bce6da-c2f4-4da8-a432-dca13ca11911/12/badge)

This package adds helpers in your ASP.NET MVC views to create links containing HTML code. This can be useful to create a link on an image, or if you want to add spans or any inline html tags in the link.

# Install using Nuget

To install MvcHtmlLink, run the following command in the Package Manager Console

    Install-Package MvcHtmlLink

# How to use

To create a link with ASP.NET MVC, you normally use the following syntax :

	@Html.ActionLink("Link text", "ActionName", "ControllerName")

If you want to add html content in the link, this library gives you a new helper method. You can use it the same way you use the `@Html.BeginForm`

	@using (Html.BeginActionLink("ActionName", "ControllerName")) {
		<img src="image.png" alt="Click here" />
	}

You have 4 new helpers, to create ActionLink or RouteLink, both in Html and Ajax. They have the same overloads as the MVC helpers for classic ActionLinks and RouteLinks

	Html.BeginActionLink
	Html.BeginRouteLink
	Ajax.BeginActionLink
	Ajax.BeginRouteLink

Please note the current version only support Ajax with Unobtrusive Javascript

	